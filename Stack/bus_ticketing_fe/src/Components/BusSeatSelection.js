import React, { useState, useEffect } from 'react';
import './BusSeatSelection.css';

const BusSeatSelection = () => {
  const totalRows = 8;
  const seatsPerRow = 4;
  const seatPrice = 200; // Set the price per seat

  // State for selected seats and booked seats
  const [selectedSeats, setSelectedSeats] = useState([]);
  const [bookedSeats, setBookedSeats] = useState([]);
  const [isBooked, setIsBooked] = useState(false);

  useEffect(() => {
    fetch('http://localhost:5110/api/Booking/BookedSeatsList', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        id: 3, // Replace with the actual bus ID you want to use
      }),
    })
      .then((response) => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
      })
      .then((data) => {
        console.log('Server Response:', data); // Log the entire response
        setBookedSeats(data.bookedSeats || []); // Ensure a default empty array if data.bookedSeats is undefined
      })
      .catch((error) => console.error('Error fetching booked seats:', error));
  }, []);
  

  // Function to check if a seat is booked
  const isSeatBooked = (seatNumber) => {
    return bookedSeats.includes(seatNumber);
  };

  // Handle click on a seat
  const handleSeatClick = (seatNumber) => {
    // If the seat is not booked, toggle the selection status
    if (!isSeatBooked(seatNumber)) {
      if (selectedSeats.includes(seatNumber)) {
        setSelectedSeats(selectedSeats.filter((seat) => seat !== seatNumber));
      } else {
        setSelectedSeats([...selectedSeats, seatNumber]);
      }
    }
  };

  // Handle booking
  const handleBookClick = () => {
    // Perform any necessary booking logic
    // For example, you can update a backend database or show a confirmation message
    setIsBooked(true);
    alert('Booking successful!');
  };

  // Calculate total price based on selected seats
  const calculateTotalPrice = () => {
    return selectedSeats.length * seatPrice;
  };

  return (
    <div className="seat-selection-container">
      <h2>Bus Seat Selection</h2>
      <div className="bus-seats">
        {[...Array(totalRows)].map((_, rowIndex) => (
          <div key={rowIndex} className="seat-row">
            {[...Array(seatsPerRow)].map((_, seatIndex) => {
              const seatNumber = rowIndex * seatsPerRow + seatIndex + 1;
              return (
                <div
                  key={seatNumber}
                  className={`seat ${
                    selectedSeats.includes(seatNumber) ? 'selected' : ''
                  } ${isSeatBooked(seatNumber) ? 'booked' : ''}`}
                  onClick={() => handleSeatClick(seatNumber)}
                >
                  {seatNumber}
                </div>
              );
            })}
          </div>
        ))}
        <div className="seat-row">
          {[...Array(5)].map((_, seatIndex) => {
            const seatNumber = totalRows * seatsPerRow + seatIndex + 1;
            return (
              <div
                key={seatNumber}
                className={`seat ${
                  selectedSeats.includes(seatNumber) ? 'selected' : ''
                } ${isSeatBooked(seatNumber) ? 'booked' : ''}`}
                onClick={() => handleSeatClick(seatNumber)}
              >
                {seatNumber}
              </div>
            );
          })}
        </div>
      </div>
      <div className="total-price-and-button-container">
        <p>Selected Seats: {selectedSeats.join(', ')}</p>
        <div className="total-price-and-button">
          <p>Total Price: ${calculateTotalPrice()}</p>
          <button onClick={handleBookClick}>Book</button>
        </div>
      </div>
    </div>
  );
};

export default BusSeatSelection;
