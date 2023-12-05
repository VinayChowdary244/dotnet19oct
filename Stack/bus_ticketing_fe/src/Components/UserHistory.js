import { useState } from "react";
import axios from "axios";
// import './UserHistory.css';

function UserHistory() {
  const [searchError, setSearchError] = useState("");
  const [searchResults, setSearchResults] = useState("");
  const [searchPerformed, setSearchPerformed] = useState(false);
  const thisUserName = localStorage.getItem("thisUserName");
  const [userNameError, setUserNameError] = useState("");

  const userData = () => {
    if (thisUserName === "") {
      setUserNameError("Please Login first!");
      return false;
    }
    return true;
  };

  const handleSearch = (event) => {
    event.preventDefault();
    setUserNameError("");
    setSearchError("");

    const isValidData = userData();

    if (!isValidData) {
      setSearchError("Please check your data");
      return;
    }

    axios
      .post("http://localhost:5110/api/Customer/UserBookingHistory", {
        userName: thisUserName,
      })
      .then((response) => {
        console.log(response.data);
        setSearchResults(response.data);
        setSearchPerformed(true);
      })
      .catch((err) => {
        console.error(err);
        setSearchError("Error searching user. Please try again.");
      });
  };

  return (
    <div className="history">
      <br />
      {!searchPerformed && (
        <button className="btn btn-primary button" onClick={handleSearch}>
          Show User history
        </button>
      )}

      {searchPerformed && (
        <center>
          <div>
            <br />
            <h2>Booking History</h2>
            <br />
            <table className="table">
          <thead>
            <tr>
            <th>S.No</th>
              <th>BookingId</th>
              <th>UserName</th>
              <th>BusId</th>
              <th>Date</th>
              <th>TotalCost</th>
              <th>SelectedSeats</th>
            </tr>
          </thead>
          <tbody>
          {searchResults.map((user, index) => (
              <tr key={user.userName}>
                <td>{index + 1}</td>
                <td>{user.bookingId}</td>
                <td>{user.userName}</td>
                <td>{user.busId}</td>
                <td>{user.date}</td>
                <td>{user.totalFare}</td>
                <td>{user.selectedSeats.join(',')}</td>
              </tr>
             ))}
          </tbody>
        </table>
          </div>
        </center>
      )}
    </div>
  );
}

export default UserHistory;
