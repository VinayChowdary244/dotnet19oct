import React, { useState, useEffect } from "react";
import './CancelledBookings.css'

function CancelledBookings() {
  const [bookingList, setBookingList] = useState([]);
  const [searchPerformed, setSearchPerformed] = useState(false);
  const userName = localStorage.getItem("thisUserName");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('http://localhost:5041/api/Booking/cancelledbookings', {
          method: 'POST',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            // 'Authorization': 'Bearer ' + localStorage.getItem("token")
          },
          body: JSON.stringify({
            userName: userName, // Use the variable here
          }),
        });

        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        console.log('Server Response:', data);
        setBookingList(data);
        setSearchPerformed(true); // Set searchPerformed to true after successful fetch
      } catch (error) {
        console.error('Error fetching booked seats:', error);
      }
    };

    fetchData();
  }, [userName]); // Include userName as a dependency

  return (
    <div>
   {searchPerformed && (
  <div className="list-container">
    <h2 className="list-heading">Cancelled Bookings</h2>
    {bookingList.map((booking, index) => (
      <div key={index} className="cancelled-booking-card">
        <div className="booking-row">
          <span><strong>Booking ID:</strong> {booking.bookingId}</span>
          <span><strong>User Name:</strong> {booking.userName}</span>
        </div>
        <div className="booking-row">
          <span><strong>Bus ID:</strong> {booking.busId}</span>
          <span><strong>Date:</strong> {booking.date}</span>
        </div>
        <div className="booking-row">
          <span><strong>Total Cost:</strong> {booking.totalFare}</span>
          <span><strong>Cancelled Date:</strong> {booking.cancelledDate}</span>
        </div>
      </div>
    ))}
  </div>
)}
    </div>
  );
}

export default CancelledBookings;
