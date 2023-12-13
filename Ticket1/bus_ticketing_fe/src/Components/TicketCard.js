import React, { useState } from 'react';
import styles from './TicketCard.module.css';

import cardImage from './cardImage.jpg';
import upiImage from './upiImage.jpg';

const TicketCard = () => {
  const [paymentMethod, setPaymentMethod] = useState(null);
  const [cardDetails, setCardDetails] = useState('');
  const [cardName, setCardName] = useState('');
  const [expDate, setExpDate] = useState('');
  const [upiId, setUpiId] = useState('');
  const thisEmail=localStorage.getItem('email');
  const thisBus = localStorage.getItem('thisBus');
  const thisDate = localStorage.getItem('thisDate');
  const thisUserName = localStorage.getItem('thisUserName');
  const thisToken = localStorage.getItem('thisToken');

  const handlePaymentMethodChange = (method) => {
    setPaymentMethod(method);
  };

  const handleCardDetailsChange = (e) => {
    setCardDetails(e.target.value);
  };

  const handleCardNameChange = (e) => {
    setCardName(e.target.value);
  };

  const handleExpDateChange = (e) => {
    setExpDate(e.target.value);
  };

  const handleUpiIdChange = (e) => {
    setUpiId(e.target.value);
  };

  const handlePaymentSubmit = () => {
    

    fetch('http://localhost:5110/api/Booking', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + localStorage.getItem("token")
        },
        
        body: JSON.stringify({
          busId:thisBus, 
          userName: thisUserName, 
          selectedSeats: localStorage.getItem('selectedSeats'),
          date: thisDate, 
          email:thisEmail,
        }),
      })
        .then((response) => {
          if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}/-`);
          }
                
    
          return response.json();
        })
        .then((data) => {
          console.log('Booking response from server:', data);
    
          
          alert('Booking successfull.\nPlease check your Email!!');
        })
        .catch((error) => console.error('Error booking seats:', error));

  };

  return (
    <div className="container">
      <h1>Select Payment Method</h1>
      <div>
        <label className="radioLabel">
          <input
            type="radio"
            name="paymentMethod"
            value="card"
            onChange={() => handlePaymentMethodChange('card')}
          />
          Card <img src={cardImage} alt="Card" className="paymentIcon" />
        </label>
        <label className="radioLabel">
          <input
            type="radio"
            name="paymentMethod"
            value="upi"
            onChange={() => handlePaymentMethodChange('upi')}
          />
          UPI <img src={upiImage} alt="UPI" className="paymentIcon" />
        </label>
      </div>
      {paymentMethod === 'card' && (
  <div>
    <h2>Enter Card Details</h2>
    <div className="cardDetailsContainer">
      <input
        type="text"
        placeholder="Card Number"
        onChange={handleCardDetailsChange}
        className="textInput cardNumber"
      />
      <div className="secondLine">
        <input
          type="text"
          placeholder="Cardholder Name"
          onChange={handleCardNameChange}
          className="textInput wideInput"
        />
        <input
          type="text"
          placeholder="Expiration Date (MM/YYYY)"
          onChange={handleExpDateChange}
          className="textInput narrowInput"
        />
      </div>
    </div>
  </div>
)}
      {paymentMethod === 'upi' && (
        <div>
          <h2>Enter UPI ID</h2>
          <input
            type="text"
            placeholder="UPI ID"
            onChange={handleUpiIdChange}
            className="textInput"
          />
        </div>
      )}

      <button onClick={handlePaymentSubmit} className="submitButton">
        Submit Payment
      </button>
    </div>
  );
};

export default TicketCard;
