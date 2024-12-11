import { configureStore } from '@reduxjs/toolkit';
import authSlice from '../slices/authSlice';
import userSlice from '../slices/userSlice';
import ChuyenXeSlice from '../slices/ChuyenXeSlice';
import VeXeSlice from '../slices/VeXeSlice';

const store = configureStore({
  reducer: {
        auth: authSlice,
        user: userSlice,
        chuyenxe: ChuyenXeSlice,
        vexe: VeXeSlice
  },
});

export default store;
