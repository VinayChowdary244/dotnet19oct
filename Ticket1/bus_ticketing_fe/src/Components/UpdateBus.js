import { useState } from "react";
import './AddBus.css'
function UpdateBus(){
    const [type,setType] = useState("");
    const [availableSeats,setSeats] = useState(0);
    const [cost,setCost] = useState(0);
    const [start,setStart] = useState("");
    const [end,setEnd] = useState("");
    const [Id,setId]=useState("");
    const [bookedSeats,setBookedSeats]=useState("");
    

    var bus;
    var clickUpdate = ()=>{
        
       bus={
        "id":Id,
        "type":type,
        "availableSeats":availableSeats,
        "bookedSeats":bookedSeats,
        "cost":cost,
        "start":start,
        "end":end
        }
        
        fetch('http://localhost:5110/api/bus/UpdateBus',{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("token")
            },
            body:JSON.stringify(bus)
        }).then( async (data)=>{
            var myData = await data.json();
            await console.log(myData);
           
        }
        ).catch((e)=>{
            console.log(e)
        })
    }


    return(
        <div className="input">
            <label className="form-control" for="pname"><b>Bus Id</b></label>
            <input id="pname" type="text" className="form-control" value={Id} onChange={(e)=>{setId(e.target.value)}}/>
            <label className="form-control" for="pname"><b>Bus Type</b></label>
            <input id="pname" type="text" className="form-control" value={type} onChange={(e)=>{setType(e.target.value)}}/>
            <label className="form-control" for="pname"><b>Start</b></label>
            <input id="pname" type="text" className="form-control" value={start} onChange={(e)=>{setStart(e.target.value)}}/>
            <label className="form-control" for="pname"><b>End</b></label>
            <input id="pname" type="text" className="form-control" value={end} onChange={(e)=>{setEnd(e.target.value)}}/>
            <label className="form-control"  for="pqty"><b>Available Seats</b></label>
            <input id="pqty" type="number" className="form-control" value={availableSeats} onChange={(e)=>{setSeats(e.target.value)}}/>
            <label className="form-control"  for="pqty"><b>Booked Seats</b></label>
            <input id="pqty" type="number" className="form-control" value={bookedSeats} onChange={(e)=>{setBookedSeats(e.target.value)}}/>
            
            <label className="form-control"  for="pprice"><b>Ticket Cost</b></label>
            <input id="pprice" type="number" className="form-control" value={cost} onChange={(e)=>{setCost(e.target.value)}}/>
            <button onClick={clickUpdate} className="btn btn-primary"><b>Update Bus</b></button>
        </div>
    );
}
export default UpdateBus;



