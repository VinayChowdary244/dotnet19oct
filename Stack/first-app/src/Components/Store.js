
import {configureStore} from '@reduxjs/toolkit';
import cartReducer from './CartSlice';

const store = configureStore({
    reducer:{
        cart:cartReducer,
    }
});

export default store;
import {createSlice} from '@reduxjs/toolkit';


const cartSlice = createSlice({
    name:"cart",
    initialState:[],
    reducers:{
        addItem:(state,action)=>{
            state.push(action.payload);
        }
    }
})

export const{addItem} = cartSlice.actions;
