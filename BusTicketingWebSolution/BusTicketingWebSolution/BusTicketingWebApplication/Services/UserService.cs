﻿using BusModelLibrary;
using BusTicketingWebApplication.Exceptions;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;
using BusTicketingWebApplication.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace BusTicketingWebApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userrepository;
        private readonly IBusRepository _busrepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userrepository, ITokenService tokenService, IBusRepository busrepository)
        {
            _userrepository = userrepository;
            _tokenService = tokenService;
            _busrepository = busrepository;
        }
        public UserDTO Login(UserDTO userDTO)
        {
            var user = _userrepository.GetById(userDTO.UserName);
            if (user != null)
            {
                HMACSHA512 hmac = new HMACSHA512(user.Key);
                var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userpass.Length; i++)
                {
                    if (user.Password[i] != userpass[i])
                        return null;
                }
                userDTO.Token = _tokenService.GetToken(userDTO);
                userDTO.Password = "";
                return userDTO;
            }
            return null;
        }

        public UserDTO Register(UserDTO userDTO)
        {
            HMACSHA512 hmac = new HMACSHA512();
            User user = new User()
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                Phone= userDTO.Phone,
                City = userDTO.City,
                Pincode = (int)userDTO.Pincode,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                Key = hmac.Key,
                Role = userDTO.Role
            };
            var result = _userrepository.Add(user);
            if (result != null)
            {
                userDTO.Password = "";
                return userDTO;
            }
            return null;

        }

        public List<Bus> GetAll()
        {
            var busses = _busrepository.GetAll();
            if (busses != null)
            {
                return busses.ToList();
            }
            throw new NoBusesAvailableException();
        }
        public List<Bus> BusSearch(BusDTO busDto)
        {
            var search = _busrepository.GetAll();
            if (search != null)
            {
                List<Bus> BusList = new List<Bus>();

                for (int i = 0; i < search.Count; i++)
                {
                    if (search[i].Start == busDto.Start)
                    {
                        if (search[i].End == busDto.End)
                        {
                            BusList.Add(search[i]);
                        }
                    }

                }
                if (BusList.Count > 0) return BusList;
                else throw new NoBusesAvailableException();



            }
            return null;

        }

        public List<User> GetAllUsers()
        {
            var users = _userrepository.GetAll();
            if (users != null)
            {
                return users.ToList();
            }
            throw new NoUsersAvailableException();
        }

        public BusDTO BookSeat(BusDTO busDTO)
        {
            var busData = _busrepository.GetById(busDTO.Id);
            
            
            busData.BookedSeats += busDTO.BookedSeats;
            busData.AvailableSeats -= busDTO.BookedSeats;
            
            if (busData != null)
            {
                var result = _busrepository.Update(busData);
                if (result != null)
                {
                    return busDTO;
                }
            }
            return null;
        }
    }
}