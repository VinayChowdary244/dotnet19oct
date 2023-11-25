import { useState } from "react";
import './AddBus.css'
function AddBus(){
    const [type,setType] = useState("");
    const [availableSeats,setSeats] = useState(0);
    const [cost,setCost] = useState(0);
    const [start,setStart] = useState("");
    const [end,setEnd] = useState("");

    var bus;
    var clickAdd = ()=>{
        alert('You clicked the button');
       bus={
        "type":type,
        "availableSeats":availableSeats,
        "cost":cost,
        "start":start,
        "end":end
        }
        console.log(bus);
        fetch('http://localhost:5110/api/Bus',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify(bus)
        }).then(
            ()=>{
                alert("Bus Added");
            }
        ).catch((e)=>{
            console.log(e)
        })
    }


    return(
        <div className="inputcontainer">
            <label className="form-control" for="pname">Bus Type</label>
            <input id="pname" type="text" className="form-control" value={type} onChange={(e)=>{setType(e.target.value)}}/>
            <label className="form-control" for="pname">Start</label>
            <input id="pname" type="text" className="form-control" value={start} onChange={(e)=>{setStart(e.target.value)}}/>
            <label className="form-control" for="pname">End</label>
            <input id="pname" type="text" className="form-control" value={end} onChange={(e)=>{setEnd(e.target.value)}}/>
            <label className="form-control"  for="pqty">Available Seats</label>
            <input id="pqty" type="number" className="form-control" value={availableSeats} onChange={(e)=>{setSeats(e.target.value)}}/>
            <label className="form-control"  for="pprice">Ticket Cost</label>
            <input id="pprice" type="number" className="form-control" value={cost} onChange={(e)=>{setCost(e.target.value)}}/>
            <button onClick={clickAdd} className="btn btn-primary">Add Bus</button>
        </div>
    );
}
export default AddBus;



