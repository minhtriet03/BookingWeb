import { configureStore } from '@reduxjs/toolkit';
import { combineReducers } from 'redux';
import { persistStore, persistReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import authSlice from '../slices/authSlice';
import userSlice from '../slices/userSlice';
import ChuyenXeSlice from '../slices/ChuyenXeSlice';
import VeXeSlice from '../slices/VeXeSlice';

const rootReducer = combineReducers({
    auth: authSlice,
    user: userSlice,
    chuyenxe: ChuyenXeSlice,
    vexe: VeXeSlice
});

const persistConfig = {
    key: 'root',
    storage,
};

const persistedReducer = persistReducer(persistConfig, rootReducer);

const store = configureStore({
    reducer: persistedReducer,
});

const persistor = persistStore(store);

export { store, persistor };