using BusTicketingWebApplication.Exceptions;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;
using System.Linq;

namespace BusTicketingWebApplication.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ICancelledBookingRepository _cancelledBookingRepository;
        private readonly IBusRepository _busRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookedSeatRepository _bookedSeatRepository;
        


        public BookingService(IBookingRepository bookingRepository, IBusRepository busRepository, IUserRepository userRepository, IBookedSeatRepository bookedSeatRepository, ICancelledBookingRepository cancelledBookingRepository)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _busRepository = busRepository;
            _bookedSeatRepository = bookedSeatRepository;
            _cancelledBookingRepository = cancelledBookingRepository;
        }
        public BookingDTO Add(BookingDTO bookingDTO)
        {
            var bus = _busRepository.GetById(bookingDTO.BusId);
            if (bookingDTO.SelectedSeats.Count <= 0 || bookingDTO.SelectedSeats.Count > 40)
                throw new InvalidNoOfTicketsEnteredException();

            if (bus != null)
            {
                float Fare = bus.Cost;

                if (bookingDTO.SelectedSeats != null)
                {
                    var AllBookedSeats = _bookedSeatRepository.GetAll();

                    if (AllBookedSeats != null)
                    {
                        bool status = false;

                        foreach (var bookedSeat in AllBookedSeats)
                        {
                            if (bookedSeat.Date == bookingDTO.Date && bookedSeat.BusId == bookingDTO.BusId )
                            {
                                bookedSeat.BookedSeats.AddRange(bookingDTO.SelectedSeats);
                                bookedSeat.AvailableSeats -= bookingDTO.SelectedSeats.Count;
                                bookedSeat.BookedSeatCount += bookingDTO.SelectedSeats.Count;
                                status = true;
                                _bookedSeatRepository.Update(bookedSeat);
                               
                                break;
                            }
                        }

                        if (!status)
                        {
                            BookedSeat newBookedSeat = new BookedSeat
                            {
                                BusId = bus.Id,
                                Date = bookingDTO.Date,
                                BookedSeats = bookingDTO.SelectedSeats,
                                AvailableSeats = 37 - bookingDTO.SelectedSeats.Count,
                                BookedSeatCount = bookingDTO.SelectedSeats.Count
                            };

                            _bookedSeatRepository.Add(newBookedSeat);
                        }
                    }
                    else
                    {
                        // If AllBookedSeats is null, create a new BookedSeat
                        BookedSeat newBookedSeat = new BookedSeat
                        {
                            BusId = bus.Id,
                            Date = bookingDTO.Date,
                            BookedSeats = bookingDTO.SelectedSeats,
                            AvailableSeats = 37 - bookingDTO.SelectedSeats.Count,
                            BookedSeatCount = bookingDTO.SelectedSeats.Count
                        };

                        _bookedSeatRepository.Add(newBookedSeat);
                    }

                    Booking booking = new Booking
                    {
                        UserName = bookingDTO.UserName,
                        BusId = bookingDTO.BusId,
                        Date = bookingDTO.Date,
                        SelectedSeats = bookingDTO.SelectedSeats,
                        TotalFare = bookingDTO.SelectedSeats.Count * Fare
                    };

                    var result = _bookingRepository.Add(booking);
                }
            }
            else
            {
                throw new InvalidBusIdException();
            }

            return bookingDTO;
        }



        public BookedSeat BookedSeatsInTheBus(BookedSeatsDTO bookedSeatsDTO)
        {
            var BookedSeat = _bookedSeatRepository.GetAll();
            if(BookedSeat != null ) {
                for( int i = 0;i<BookedSeat.Count;i++ )
                {
                    if (BookedSeat[i].BusId == bookedSeatsDTO.BusId)
                    {
                        if (BookedSeat[i].Date == bookedSeatsDTO.Date)
                        {
                            return BookedSeat[i];
                        }
                    }
                }
            }
            return null;
        }

        public List<Booking> GetBookings()
        {
            var bookings = _bookingRepository.GetAll();
            if (bookings != null)
            {
                return bookings.ToList();
            }
            throw new NoBookingsAvailableException();
        }



        public BookedSeatsDTO RemoveBooking(BookedSeatsDTO bookedSeatsDTO)
        {
            var BookingToBeRemoved = _bookingRepository.GetById(bookedSeatsDTO.BusId);
            if (BookingToBeRemoved != null)
            {
                CancelledBooking cancelledBooking = new CancelledBooking();
                cancelledBooking.BookingId = BookingToBeRemoved.BookingId;
                cancelledBooking.UserName  =BookingToBeRemoved.UserName;
                cancelledBooking.BusId = BookingToBeRemoved.BusId;
                cancelledBooking.Date = BookingToBeRemoved.Date;
                cancelledBooking.CancelledSeats = BookingToBeRemoved.SelectedSeats;
                cancelledBooking.TotalFare = BookingToBeRemoved.TotalFare;
                cancelledBooking.CancelledDate= DateTime.Now;
                _cancelledBookingRepository.Add(cancelledBooking);

                var result = _bookingRepository.Delete(bookedSeatsDTO.BusId);
                if (result != null)
                {
                    var bus = _busRepository.GetById(BookingToBeRemoved.BusId);
                   

                    var AllBookedSeats=_bookedSeatRepository.GetAll();
                    if (AllBookedSeats != null)
                    {
                        for(int i = 0; i < AllBookedSeats.Count; i++)
                        {
                            if (AllBookedSeats[i].Id == bookedSeatsDTO.BusId)
                            {
                                if (AllBookedSeats[i].Date == bookedSeatsDTO.Date)
                                {
                                    AllBookedSeats[i].BookedSeats.RemoveAll(seat => BookingToBeRemoved.SelectedSeats.Contains(seat));
                                    AllBookedSeats[i].AvailableSeats += BookingToBeRemoved.SelectedSeats.Count;
                                    AllBookedSeats[i].BookedSeatCount -= BookingToBeRemoved.SelectedSeats.Count;

                                    _bookedSeatRepository.Update(AllBookedSeats[i]);

                                }
                            }

                        }
                    }

                   // var bookedBusSeats = _bookedSeatRepository.GetById(BookingToBeRemoved.BusId);

                   //bookedBusSeats.BookedSeats.RemoveAll(seat => BookingToBeRemoved.SelectedSeats.Contains(seat));

                   // _bookedSeatRepository.Update(bookedBusSeats);
                    return bookedSeatsDTO;
                }
            }
            return null;
        }

        
    }
}
