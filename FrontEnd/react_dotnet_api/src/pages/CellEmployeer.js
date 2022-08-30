import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";
import { useEffect, useState } from "react";
import { Table } from "reactstrap";
import HeaderPlatform from "../components/HeaderPlatform/HeaderPlatform";
import {useParams} from 'react-router-dom';

function CellEmployeer() {

  const baseUrl = "https://localhost:5001/api/CellEmployeers";
  const [data, setData] = useState([]);

   let codecell = useParams().codeCell;
   let date = useParams().date;

  const pedidoGetByCellEmployeer = async () => {
    await axios
      .get(baseUrl + "/" + codecell + "/" + date)
      .then((response) => {
        console.log(response);
        setData(response.data.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  useEffect(() => {
    pedidoGetByCellEmployeer();
  }, []);

  return (
    <div>
      <HeaderPlatform />
      <div className="container">
        <h2>Operações</h2>
        <Table bordered hover responsive size="sm">
          <thead className="table-warning">
            <tr>
              <th scope="col">Matricula Funcionario</th>
              <th scope="col">Nome</th>
              <th scope="col">Função</th>
              <th scope="col">Nivel</th>
              <th scope="col">Operação</th>
            </tr>
          </thead>
          <tbody className="table-light">
            {data.map((CellEmployeer) => (
              <tr key={CellEmployeer.registerEmployeer}>
                <td>{CellEmployeer.registerEmployeer}</td>
                <td>{CellEmployeer.nameEmployeer}</td>
                <td>{CellEmployeer.office}</td>
                <td>{CellEmployeer.levelEmployeer}</td>
                <td>
                  <button className="btn btn-primary">Editar</button>
                  <button className="btn btn-danger">Excluir</button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    </div>
  );
}

export default CellEmployeer;
