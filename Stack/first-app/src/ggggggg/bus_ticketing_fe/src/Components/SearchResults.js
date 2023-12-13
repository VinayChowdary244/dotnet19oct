import React, { useState, useEffect } from 'react';

function SearchResults() {
  const [searchResults, setSearchResults] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('http://localhost:5110/api/Customer/BusSearch');
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        setSearchResults(data);
      } catch (error) {
        console.error('Error fetching search results:', error);
        setError(error.message || 'An error occurred while fetching search results.');
      }
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Error: {error}</div>;
  }

  return (
    <div>
      <h2>Search Results</h2>
      <table>
        <thead>
          <tr>
            <th>BusId</th>
            <th>Type</th>
            <th>From</th>
            <th>To</th>
            <th>Date</th>
            <th>Fare</th>
          </tr>
        </thead>
        <tbody>
          {searchResults.map((bus) => (
            <tr key={bus.busId}>
              <td>{bus.id}</td>
              <td>{bus.type}</td>
              <td>{bus.start}</td>
              <td>{bus.end}</td>
              <td>{}</td>
              <td>{bus.cost}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default SearchResults;
