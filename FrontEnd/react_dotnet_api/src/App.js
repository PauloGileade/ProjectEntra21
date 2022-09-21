import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import DashBoard from "./pages/DashBoard";
import Employeer from "./pages/Employeer";
import Product from "./pages/Product";
import Order from "./pages/Order";
import Cell from "./pages/Cell";
import CellEmployeer from "./pages/CellEmployeer";
import Platform from "./pages/Platform";
import TotalPartial from "./pages/totalPartial";

function App() {
  return (
    // rotas
    <Router>
      <Routes>
        <Route index element={<DashBoard />}></Route>
        <Route
          path="/dashBoard/:codeCell/:date"
          element={<DashBoard />}
        ></Route>
        <Route path="/dashBoard" element={<DashBoard />}></Route>
        <Route path="/platform" element={<Platform />}></Route>
        <Route path="/employeer" element={<Employeer />}></Route>
        <Route path="/product" element={<Product />}></Route>
        <Route path="/cell" element={<Cell />}></Route>
        <Route
          path="/cellEmployeer/:codeCell/:date"
          element={<CellEmployeer />}
        ></Route>
        <Route path="/order/:codeCell/:date" element={<Order />}></Route>
        <Route
          path="/order/:dateStart/:dateEnd/:register"
          element={<Order />}
        ></Route>
        <Route
          path="/order/:register/:codeProduct/:dateStart/:dateEnd"
          element={<Order />}
        ></Route>
        <Route
          path="/totalPartial/:phaseCell/:codeCell"
          element={<TotalPartial />}
        ></Route>
      </Routes>
    </Router>
  );
}

export default App;
