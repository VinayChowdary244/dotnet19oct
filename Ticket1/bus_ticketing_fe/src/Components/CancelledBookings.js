import React, { useState, useEffect } from "react";
import './CancelledBookings.css';

function CancelledBookings() {
  const [bookingList, setBookingList] = useState([]);
  const [searchPerformed, setSearchPerformed] = useState(false);
  const userName = localStorage.getItem("thisUserName"); // Replace with the actual user name

  useEffect(() => {
    fetch('http://localhost:5110/api/Booking/cancelledbookings', {
      method: 'POST',
      headers: {
        'Accept':'application/json',
        'Content-Type':'application/json'
       //'Authorization': 'Bearer ' + localStorage.getItem("token")

      },
      body: JSON.stringify({
        userName: userName, 
        
      }),
    })
      .then((response) => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
      })
      .then((data) => {
        console.log('Server Response:', data);
        setBookingList(data);
        
      })
      .catch((error) => console.error('Error fetching booked seats:', error));
  }, []);

  return (
    <div>
      {searchPerformed && (
        <div>
          <h2 className="list-heading">Cancelled Bookings</h2>
          
          <center>
            <table className="table">
              <thead>
                <tr>
                  <th>S.No</th>
                  <th>BookingId</th>
                  <th>UserName</th>
                  <th>BusId</th>
                  <th>Date</th>
                  <th>TotalCost</th>
                  <th>Cancelled Date</th>
                  <th>SelectedSeats</th>
                </tr>
              </thead>
              <tbody>
                {bookingList.map((booking, index) => (
                  <tr key={booking.userName}>
                    <td>{index + 1}</td>
                    <td>{booking.bookingId}</td>
                    <td>{booking.userName}</td>
                    <td>{booking.busId}</td>
                    <td>{booking.date}</td>
                    <td>{booking.totalFare}</td>
                    <td>{booking.cancelledDate}</td>
                    <td>{booking.selectedSeats}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </center>
        </div>
      )}
    </div>
  );
}

export default CancelledBookings;
