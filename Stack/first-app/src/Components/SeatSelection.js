import React, { useState } from 'react';
import './SeatSelection.css'
const BusSeatSelection = () => {
    const totalRows = 8;
    const seatsPerRow = 4;
    const totalSeats = totalRows * seatsPerRow;
    const seatPrice = 200; // Set the price per seat
  
    const [selectedSeats, setSelectedSeats] = useState([]);
  
    const handleSeatClick = (seatNumber) => {
      // Toggle the selection status of the clicked seat
      if (selectedSeats.includes(seatNumber)) {
        setSelectedSeats(selectedSeats.filter(seat => seat !== seatNumber));
      } else {
        setSelectedSeats([...selectedSeats, seatNumber]);
      }
    };
  
    const calculateTotalPrice = () => {
      return selectedSeats.length * seatPrice;
    };
  
    return (
      <div>
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
        <div>
          <p>Selected Seats: {selectedSeats.join(', ')}</p>
          <p>Total Price: ${calculateTotalPrice()}</p>
        </div>
      </div>
    );
  };
  
  export default BusSeatSelection;