import { useState, useEffect } from "react";
import axios from "axios";
import './UserHistory.css';

function UserHistory() {
  const thisUserName = localStorage.getItem("thisUserName");
  const [userNameError, setUserNameError] = useState("");
  const [searchError, setSearchError] = useState("");
  const [completedBookings, setCompletedBookings] = useState([]);
  const [upcomingBookings, setUpcomingBookings] = useState([]);
  const [showUpcoming, setShowUpcoming] = useState(true); // Initially show upcoming bookings
  const [searchPerformed, setSearchPerformed] = useState(false);

  useEffect(() => {
    // This will run when the component is mounted
    handleSearch();
  }, []); // The empty dependency array ensures that it runs only once on mount

  const userData = () => {
    if (thisUserName === "") {
      setUserNameError("Please Login first!");
      return false;
    }

    return true;
  };

  const handleSearch = () => {
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
        const today = new Date();
        const completed = response.data.filter(
          (booking) => new Date(booking.date) < today
        );
        const upcoming = response.data.filter(
          (booking) => new Date(booking.date) >= today
        );

        setCompletedBookings(completed);
        setUpcomingBookings(upcoming);
        setSearchPerformed(true);
      })
      .catch((err) => {
        console.error(err);
        setSearchError("Error searching user. Please try again.");
      });
  };

  const handleCancelBooking = (bookingId) => {
    axios
    .delete("http://localhost:5110/api/Booking/CancelBooking", {
      data: { id: bookingId }, // Use the data property to send the payload
    })
    .then((response) => {
      // Handle the response as needed
    })
    .catch((err) => {
      console.error(err);
      setSearchError("Error cancelling the ticket. Please try again.");
    });


    console.log(`Cancel booking with ID: ${bookingId}`);
  };

  const toggleBookings = () => {
    setShowUpcoming(!showUpcoming);
  };

  return (
    <div className="history">
      {searchPerformed && (
        <center>
          <div>
            <br />
            <button className="btn-success" onClick={toggleBookings}>
              {showUpcoming ? "Show Completed Bookings" : "Show Upcoming Bookings"}
            </button>
            <br />
            <h2>{showUpcoming ? "Upcoming" : "Completed"} Bookings</h2>
            <br />
            <table className="table">
              {/* Render bookings based on the showUpcoming state */}
              <thead>
                <tr>
                  <th>S.No</th>
                  <th>BookingId</th>
                  <th>UserName</th>
                  <th>BusId</th>
                  <th>Date</th>
                  <th>TotalCost</th>
                  <th>SelectedSeats</th>
                  {showUpcoming && <th>Action</th>}
                </tr>
              </thead>
              <tbody>
                {showUpcoming
                  ? upcomingBookings.map((user, index) => (
                      <tr key={user.userName} className="table-row">
                        <td>{index + 1}</td>
                        <td>{user.bookingId}</td>
                        <td>{user.userName}</td>
                        <td>{user.busId}</td>
                        <td>{user.date}</td>
                        <td>{user.totalFare}</td>
                        <td>{user.selectedSeats.join(",")}</td>
                        <td>
                          <button
                            className="btn-cancel"
                            onClick={() => handleCancelBooking(user.bookingId)}
                          >
                            Cancel
                          </button>
                        </td>
                      </tr>
                    ))
                  : completedBookings.map((user, index) => (
                      <tr key={user.userName} className="table-row">
                        <td>{index + 1}</td>
                        <td>{user.bookingId}</td>
                        <td>{user.userName}</td>
                        <td>{user.busId}</td>
                        <td>{user.date}</td>
                        <td>{user.totalFare}</td>
                        <td>{user.selectedSeats.join(",")}</td>
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
