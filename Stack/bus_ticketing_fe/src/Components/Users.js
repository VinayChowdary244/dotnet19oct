import { useState } from "react";

function Users() {
  const [userList, setUserList] = useState([]);
  const [searchPerformed, setSearchPerformed] = useState(false);

  var getUsers = (event) => {
    event.preventDefault();
    
       fetch('http://localhost:5110/api/Customer/GetAllUsers', {
        method: 'GET',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + localStorage.getItem("token")
        }
      }).then( async (data)=>{
        var myData = await data.json();
        await console.log(myData);
        await setUserList(myData);
        await setSearchPerformed("true");
    }
).catch((e)=>{
    console.log(e)
})
}

  return (
    <div>
      <h1 className="alert alert-success">Users</h1>
      <button className="btn btn-success" onClick={getUsers}>Get All Users</button>

      {searchPerformed && (
        <div>
          <center>
          <h2>Booking History</h2>
          <table className="table">
            <thead>
              <tr>
                <th>S.No</th>
                <th>UserName</th>
                <th>Email</th>
                <th>Phone</th>
                <th>City</th>
                <th>Pincode</th>
                <th>Role</th>
              </tr>
            </thead>
            <tbody>
              {userList.map((user, index) => (
                <tr key={user.userName}>
                  <td>{index + 1}</td>
                  <td>{user.userName}</td>
                  <td>{user.email}</td>
                  <td>{user.phone}</td>
                  <td>{user.city}</td>
                  <td>{user.pincode}</td>
                  <td>{user.role}</td>
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

export default Users;
