import React, { useState, useEffect } from "react";

function Buses() {
  const [busList, setBusList] = useState([]);
  const [searchPerformed, setSearchPerformed] = useState(false);

  useEffect(() => {
    // Fetch buses when the component is mounted
    getBuses();
  }, []); // Empty dependency array ensures this effect runs once when mounted

  var getBuses = () => {
    fetch("http://localhost:5110/api/bus", {
      method: "GET",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
        Authorization: "Bearer " + localStorage.getItem("token"),
      },
    })
      .then(async (data) => {
        var myData = await data.json();
        await setBusList(myData);
        await setSearchPerformed(true);
        var Id = data.Id;
        localStorage.setItem("Id", Id);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  var checkBuses = busList.length > 0 ? true : false;

  return (
    <div>
      <center>
        <h1 className="alert alert-success">
          <center>Buses</center>
        </h1>
      </center>
      {searchPerformed && (
        <div>
          <center>
            <table className="table">
              <thead>
                <tr>
                  <th>S.No</th>
                  <th>BusId</th>
                  <th>Type</th>
                  <th>Cost</th>
                  <th>Available Seats</th>
                  <th>Booked Seats</th>
                  <th>Start</th>
                  <th>End</th>
                </tr>
              </thead>
              <tbody>
                {busList.map((bus, index) => (
                  <tr key={bus.busId}>
                    <td>{index + 1}</td>
                    <td>{bus.id}</td>
                    <td>{bus.type}</td>
                    <td>{bus.cost}</td>
                    <td>{bus.availableSeats}</td>
                    <td>{bus.bookedSeats}</td>
                    <td>{bus.start}</td>
                    <td>{bus.end}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </center>
        </div>
      )}
    </div>
  );
}

export default Buses;

