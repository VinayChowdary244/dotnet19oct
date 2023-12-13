import { useState, useEffect } from "react";
import axios from "axios";
import './DriverDetails.css'
function DriverDetails() {
  const [busIdError, setBusIdError] = useState("");
  const [searchError, setSearchError] = useState("");
  const [searchResults, setSearchResults] = useState([]);
  const [searchPerformed, setSearchPerformed] = useState(false);

  useEffect(() => {
    // This will run when the component is mounted
    fetchData();
  }, []); // The empty dependency array ensures that it runs only once on mount

  const fetchData = () => {
    setBusIdError("");
    setSearchError("");
  
    axios
      .post("http://localhost:5110/api/Bus/GetBusById", {
        id: 1
      })
      .then((response) => {
        console.log(response.data);
  
        // Ensure that response.data is an array before setting it to searchResults
        if (Array.isArray(response.data)) {
          setSearchResults(response.data);
          setSearchPerformed(true);
        } else {
          setSearchError("Invalid response format. Please check the API.");
        }
      })
      .catch((err) => {
        console.error(err);
        setSearchError("Error searching bus. Please try again.");
      });
  };

  return (
    <div>
      <div>
        <h2>Driver Details</h2>
        {searchResults.map((bus, index) => (
          <div key={index} className="bus-details-box">
            <h3>Driver Details</h3>
            <p><strong>Name:</strong> {bus.driverName}</p>
            <p><strong>Phone:</strong> {bus.driverPhone}</p>
            <p><strong>Rating:</strong> {bus.driverRating}</p>
            <p><strong>Age:</strong> {bus.driverAge}</p>
          </div>
        ))}
      </div>
    </div>
  );
}

export default DriverDetails;
