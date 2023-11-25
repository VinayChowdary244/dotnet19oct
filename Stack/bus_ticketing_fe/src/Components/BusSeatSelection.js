import React, { useState } from 'react';
import './BusSeatSelection.css';

const BusSeatSelection = () => {
  const totalRows = 8;
  const seatsPerRow = 4;
  const seatPrice = 200; // Set the price per seat

  const [selectedSeats, setSelectedSeats] = useState([]);
  const [isBooked, setIsBooked] = useState(false);

  const handleSeatClick = (seatNumber) => {
    // Toggle the selection status of the clicked seat
    if (selectedSeats.includes(seatNumber)) {
      setSelectedSeats(selectedSeats.filter(seat => seat !== seatNumber));
    } else {
      setSelectedSeats([...selectedSeats, seatNumber]);
    }
  };

  const handleBookClick = () => {
    // Perform any necessary booking logic
    // For example, you can update a backend database or show a confirmation message
    setIsBooked(true);
    alert("Booking successful!");
  };

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
                  className={`seat ${selectedSeats.includes(seatNumber) ? 'selected' : ''}`}
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
                className={`seat ${selectedSeats.includes(seatNumber) ? 'selected' : ''}`}
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
