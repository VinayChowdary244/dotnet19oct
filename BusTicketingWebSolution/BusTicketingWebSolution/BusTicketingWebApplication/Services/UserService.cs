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
        private readonly IBookingRepository _bookingRepository;

        public UserService(IUserRepository userrepository, ITokenService tokenService, IBusRepository busrepository,IBookingRepository bookingRepository)
        {
            _userrepository = userrepository;
            _tokenService = tokenService;
            _busrepository = busrepository;
            _bookingRepository = bookingRepository;
        }
        public User Login(UserDTO userDTO)
        {
            var user = _userrepository.GetById(userDTO.UserName);
            if (user != null)
            {
                var User=_userrepository.GetById(userDTO.UserName);
                HMACSHA512 hmac = new HMACSHA512(user.Key);
                var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userpass.Length; i++)
                {
                    if (user.Password[i] != userpass[i])
                        return null;
                }
                userDTO.Token = _tokenService.GetToken(userDTO);
                userDTO.Password = "";
                return User;
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
        public List<Bus> BusSearch(BusSearchDTO busSearchDto)
        {
            var search = _busrepository.GetAll();
            if (search != null)
            {
                List<Bus> BusList = new List<Bus>();

                for (int i = 0; i < search.Count; i++)
                {
                    if (search[i].Start == busSearchDto.Start)
                    {
                        if (search[i].End == busSearchDto.End)
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

        //public BusDTO BookSeat(BusDTO busDTO)
        //{
        //    var busData = _busrepository.GetById(busDTO.Id);
            
            
        //    busData.BookedSeats += busDTO.BookedSeats;
        //    busData.AvailableSeats -= busDTO.BookedSeats;
            
        //    if (busData != null)
        //    {
        //        var result = _busrepository.Update(busData);
        //        if (result != null)
        //        {
        //            return busDTO;
        //        }
        //    }
        //    return null;
        //}
        public List<Booking> GetBookingHistory(UserNameDTO userNameDTO)
        {
            var booking = _bookingRepository.GetAll();
            if (booking != null)
            {
                List<Booking> BookingHistory = new List<Booking>();
                for (int i = 0;i<booking.Count;i++)
                {
                    if (booking[i].UserName == userNameDTO.UserName)
                    {
                        BookingHistory.Add(booking[i]);
                    }
                }
                if (BookingHistory.Count > 0) return BookingHistory;
                else throw new NoBookingsYetException();
            }
            return null;
        }


        public UserUpdateDTO UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            var userData = _userrepository.GetById(userUpdateDTO.UserName);
           
            if (userData != null)
            {
                userData.UserName = userUpdateDTO.UserName;
                userData.Email = userUpdateDTO.Email;
                userData.City = userUpdateDTO.City;
                userData.Phone = userUpdateDTO.Phone;
                userData.Pincode = userUpdateDTO.Pincode;
                var res = _userrepository.Update(userData);
                if (res != null)
                {
                    return userUpdateDTO;
                }
            }
            throw new NoUsersAvailableException();
        }
    }
}