// BusTicket.js

import React, { useEffect, useState } from 'react';
import './BusTicket.css';

const BusTicket = () => {
  const [fromLocation, setFromLocation] = useState('');
  const [toLocation, setToLocation] = useState('');
  const [busId, setBusId] = useState('');
  const [seatNumbers, setSeatNumbers] = useState([]);
  const [busType, setBusType] = useState('');

  useEffect(() => {
    // Retrieve details from local storage
    setFromLocation(localStorage.getItem('fromLocation'));
    setToLocation(localStorage.getItem('toLocation'));
    setBusId(localStorage.getItem('thisBus'));
    setSeatNumbers(JSON.parse(localStorage.getItem('selectedSeats')));
    setBusType(localStorage.getItem('busType'));
  }, []);

  return (
    <div className="bus-ticket">
      <h2>Bus Ticket</h2>
      <div className="ticket-details">
        <div>
          <strong>From:</strong> {fromLocation}
        </div>
        <div>
          <strong>To:</strong> {toLocation}
        </div>
        <div>
          <strong>Bus ID:</strong> {thisBus}
        </div>
        <div>
          <strong>Seat Numbers:</strong> {selectedSeats}
        </div>
        <div>
          <strong>Bus Type:</strong> {busType}
        </div>
      </div>
    </div>
  );
};

export default BusTicket;
