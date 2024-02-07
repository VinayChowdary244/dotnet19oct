import { useState, useEffect } from 'react';
import './RedBus.css'; // Import the CSS file
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
          date: localStorage.getItem('selectedDate')
         

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
return(
<div>
      <h2>Available Busses</h2>
      <center>
        <table className="table">
          <thead>
            <tr>
              <th>S.No</th>
              <th>BusId</th>
              <th>Type</th>
              <th>From</th>
              <th>To</th>
              <th>Date</th>
              <th>Fare</th>
              <th>
                <center>Book now</center>
              </th>
            </tr>
          </thead>
          <tbody>
            {searchResults.map((bus, index) => (
              <tr key={bus.busId}>
                <td>{index + 1}</td>
                <td>{bus.id}</td>
                <td>{bus.type}</td>
                <td>{bus.start}</td>
                <td>{bus.end}</td>
                <td>{selectedDate}</td>
                <td>₹{bus.cost}/-</td>
                <td>
                  <center>
                    <button
                      className="book-button"
                      onClick={() =>
                        handleBook(
                          bus.id,
                          selectedDate,
                          bus.cost,
                          bus.type,
                          bus.startTime
                        )
                      }
                    >
                      Book
                    </button>
                  </center>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </center>
    </div>
  

);
}

export default SearchedBusses;