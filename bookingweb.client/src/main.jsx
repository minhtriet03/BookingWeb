import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './App.jsx'
import { Provider } from 'react-redux'
import 'bootstrap/dist/css/bootstrap.css';
import store from './redux/store/store.jsx';
//import { setupInterceptors } from './utils/axiosInstance.js';

//setupInterceptors(store);


createRoot(document.getElementById('root')).render(
  <StrictMode>
    <Provider store={store}>
    <App />
    </Provider>
  </StrictMode>,
)
