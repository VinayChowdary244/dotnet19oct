import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./SearchBus.css";

function SearchForm() {
  const [start, setStart] = useState("");
  const [end, setEnd] = useState("");
  const [selectedDate, setSelectedDate] = useState("");
  const [startError, setStartError] = useState("");
  const [searchError, setSearchError] = useState("");
  const navigate = useNavigate();

  const checkUserData = () => {
    if (start === "") {
      setStartError("Start location cannot be empty");
      return false;
    }

    if (end === "") {
      setStartError("End location cannot be empty");
      return false;
    }

    if (selectedDate === "") {
      setStartError("Please select a date");
      return false;
    }

    return true;
  };

  const handleSearch = (event) => {
    event.preventDefault();
    setStartError("");
    setSearchError("");

    const isValidData = checkUserData();

    if (!isValidData) {
      setSearchError("Please check your data");
      return;
    }

    // Redirect to the search results page with query parameters
    navigate(`/search-results?start=${start}&end=${end}&date=${selectedDate}`);
  };

  return (
    <div>
      <form className="StartEndInput">
        <label className="Start_End_Form">From</label>
        <input
          type="text"
          className="form-control"
          value={start}
          onChange={(e) => setStart(e.target.value)}
        />
        {startError && <p className="error-message">{startError}</p>}

        <label className="Start_End_Form">To</label>
        <input
          type="text"
          className="form-control"
          value={end}
          onChange={(e) => setEnd(e.target.value)}
        />
        {searchError && <p className="error-message">{searchError}</p>}

        <label className="Start_End_Form">Date</label>
        <input
          type="date"
          className="form-control"
          value={selectedDate}
          onChange={(e) => setSelectedDate(e.target.value)}
        />
        {searchError && <p className="error-message">{searchError}</p>}

        <button className="btn btn-primary button" onClick={handleSearch}>
          Search Bus
        </button>
      </form>
    </div>
  );
}

export default SearchForm;
