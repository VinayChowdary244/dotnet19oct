// Payment.js

import React, { useState } from 'react';

function Payment({ totalAmount, onPaymentSuccess, onCancel }) {
  const [selectedPaymentMethod, setSelectedPaymentMethod] = useState('');

  const handlePayment = () => {
    // Perform payment processing based on the selectedPaymentMethod
    // You can integrate with a payment gateway or handle different methods accordingly
    // For simplicity, this example assumes a successful payment
    onPaymentSuccess();
  };

  return (
    <div>
      <h2>Select Payment Method</h2>
      <label>
        <input
          type="radio"
          value="upi"
          checked={selectedPaymentMethod === 'upi'}
          onChange={() => setSelectedPaymentMethod('upi')}
        />
        UPI
      </label>
      <label>
        <input
          type="radio"
          value="card"
          checked={selectedPaymentMethod === 'card'}
          onChange={() => setSelectedPaymentMethod('card')}
        />
        Credit/Debit Card
      </label>

      <button onClick={handlePayment}>Make Payment</button>
      <button onClick={onCancel}>Cancel</button>
    </div>
  );
}

export default Payment;
