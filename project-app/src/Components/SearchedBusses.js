// SearchedBusses.js
import React, { useState, useEffect } from 'react';
import './SearchedBusses.css'; // Import the CSS file
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

function SearchedBusses() {
  const [fromLocation, setFromLocation] = useState('');
  const [toLocation, setToLocation] = useState('');
  const [selectedDate, setSelectedDate] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [searchError, setSearchError] = useState('');

  const [searchPerformed, setSearchPerformed] = useState(false);
  const [thisBus, setThisBus] = useState(null);
  const [thisDate, setThisDate] = useState(null);
  const [type, setType] = useState(null);
  const [startTime, setStartTime] = useState(null);

  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.post('http://localhost:5041/api/Customer/BusSearch', {
          start: localStorage.getItem('fromLocation'),
          end: localStorage.getItem('toLocation'),
          date: localStorage.getItem('selectedDate'),
        });

        console.log(response.data);
        setSearchResults(response.data);
        setSearchPerformed(true);
      } catch (error) {
        console.error(error);
        setSearchError('Error searching buses. Please try again.');
      }
    };

    fetchData();
  }, [fromLocation, toLocation, selectedDate]);

  const handleBook = (id, selectedDate, cost, type, startTime) => {
    setThisBus(id);
    setThisDate(selectedDate);

    localStorage.setItem('cost', cost);
    localStorage.setItem('thisBus', id);
    localStorage.setItem('thisDate', selectedDate);
    localStorage.setItem('type', type);
    localStorage.setItem('startTime', startTime);

    navigate('/BusSeatSelection');
  };

  return (
    <div>
      <h2>Available Busses</h2>
      <div className="bus-tiles">
        {searchResults.map((bus, index) => (
          <div key={bus.busId} className="bus-tile">
            <div className="tile-content">
              {/* Placeholder for Bus Image */}
              <img
                src="https://via.placeholder.com/50"  // Replace with actual bus image link
                alt="Bus"
                style={{ marginRight: '10px' }}
              />
              <div className="tile-details">
                <div>
                  <p>S.No: {index + 1}</p>
                  <p>BusId: {bus.id}</p>
                  <p>Type: {bus.type}</p>
                </div>
                <div>
                  <p>From: {bus.start}</p>
                  <p>To: {bus.end}</p>
                  <p>Date: {selectedDate}</p>
                </div>
                <div>
                  <p>Fare: ₹{bus.cost}/-</p>
                </div>
              </div>
            </div>
            <center>
              <button
                className="book-button"
                onClick={() =>
                  handleBook(bus.id, selectedDate, bus.cost, bus.type, bus.startTime)
                }
              >
                Book
              </button>
            </center>
          </div>
        ))}
      </div>
    </div>
  );
}

export default SearchedBusses;
