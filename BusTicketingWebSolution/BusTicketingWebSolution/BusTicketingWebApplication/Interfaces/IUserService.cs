﻿using BusModelLibrary;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;

namespace BusTicketingWebApplication.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
        List<Bus> BusSearch(BusDTO busDTO);
        BusDTO BookSeat(BusDTO busDTO);
        List<User> GetAllUsers();
    }
}
