import "./MainDashBoard.css";
import * as React from "react";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";
import { useState, useEffect } from "react";
import Stack from "@mui/material/Stack";
import Button from "@mui/material/Button";
import { Modal, ModalBody, ModalFooter, ModalHeader, Table } from "reactstrap";
import { useParams } from "react-router-dom";
import axios from "axios";

const MainDashBoard = () => {
  const [data, setData] = useState([]);
  const [modalFiltro, setModalFiltro] = useState(false);
  const [celula, setCelula] = useState("");
  const [dataDados, setDataDados] = useState("");

  const baseUrl = "https://localhost:5001/api/Orders";

  let codecell = useParams().codeCell;
  let date = useParams().date;

  const abrirFecharModalFiltro = (value) => {
    setCelula(value);
    setModalFiltro(!modalFiltro);
  };

  const setDataLimpa = (value) => {
    setDataDados(value.split("/").reverse().join("-"));
  };

  function redirect() {
    window.location.href = "/dashboard/" + celula + "/" + dataDados;
  }

  const pedidoGet = async () => {
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
    pedidoGet();
  }, []);

debugger
  return (
    <div>
      <main>
        <div className="main__container">
          <div className="main__title">
            <div className="main__greeting">
              <h1>Olá</h1>
              <p>Bem vindo ao seu Painel De Controle</p>
            </div>
          </div>
          <div className="charts__left__title">
            <div>
              <h1>Buscar Orderns</h1>
            </div>
          </div>
          <FormControl>
            <FormLabel id="demo-row-radio-buttons-group-label"></FormLabel>
          </FormControl>
          <Stack spacing={5} direction="row">
            <Button
              variant="contained"
              onClick={() => abrirFecharModalFiltro(1)}
            >
              Celula 1
            </Button>
            <Button
              variant="contained"
              onClick={() => abrirFecharModalFiltro(2)}
            >
              Celula 2
            </Button>
            <Button
              variant="contained"
              onClick={() => abrirFecharModalFiltro(3)}
            >
              Celula 3
            </Button>
            <Button
              variant="contained"
              onClick={() => abrirFecharModalFiltro(4)}
            >
              Celula 4
            </Button>
            <Button
              variant="contained"
              onClick={() => abrirFecharModalFiltro(5)}
            >
              Celula 5
            </Button>
            <Button
              variant="contained"
              onClick={() => abrirFecharModalFiltro(6)}
            >
              Celula 6
            </Button>
          </Stack>
          <br />
          <h2>Painel De Orderns</h2>
          <Table bordered hover responsive size="sm">
            <thead className="table-warning">
              <tr>
                <th>Codigo celula</th>
                <th>Codigo produto</th>
                <th>Nome produto</th>
                <th>Matricula funcionario</th>
                <th>Nome funcionario</th>
                <th>Quantidade entrada</th>
                <th>Quantidade saida</th>
                <th>Data criação</th>
              </tr>
            </thead>
            <tbody className="table-light">
              {data.map((order) => (
                <tr key={order.codeCell}>
                  <td>{order.codeCell}</td>
                  <td>{order.codeProduct}</td>
                  <td>{order.nameProduct}</td>
                  <td>{order.registerEmployeer}</td>
                  <td>{order.nameEmployeer}</td>
                  <td>{order.amountEnter}</td>
                  <td>{order.amountFinished}</td>
                  <td>{order.creatAt}</td>
                </tr>
              ))}
            </tbody>
          </Table>
          <Modal isOpen={modalFiltro}>
            <ModalHeader>Buscar Por Filtro</ModalHeader>
            <ModalBody>
              <div className="form-group">
                <label>Celula:</label>
                <br />
                <input
                  type="number"
                  className="form-control"
                  name="codeCell"
                  value={celula}
                  readOnly
                ></input>
              </div>
              <div className="form-group">
                <label>Data:</label>
                <br />
                <input
                  type="date"
                  className="form-control"
                  name="data"
                  onChange={(e) => setDataLimpa(e.target.value)}
                ></input>
              </div>
            </ModalBody>

            <ModalFooter>
              <button className="btn btn-primary" onClick={() => redirect()}>
                Buscar
              </button>
              <button
                className="btn btn-danger"
                onClick={() => abrirFecharModalFiltro()}
              >
                Cancelar
              </button>
            </ModalFooter>
          </Modal>
          <div className="container">
            <div className="main__cards">
              <div className="card">
                <i className="fa fa-file-text fa-2x text-lightblue"></i>
                <div className="card_inner">
                  <h5 className="text-primary-p">Total De Orderns</h5>
                  <span className="font-bold text-title">578</span>
                </div>
              </div>

              <div className="card">
                <i className="fa-solid fa-money-bill-1-wave"></i>
                <div className="card_inner">
                  <h5 className="text-primary-p">Total De Entrada</h5>
                  <span className="font-bold text-title">500</span>
                </div>
              </div>

              <div className="card">
                <i className="fa fa-archive fa2x text-yellow"></i>
                <div className="card_inner">
                  <h5 className="text-primary-p">Total De Saida</h5>
                  <span className="font-bold text-title">670</span>
                </div>
              </div>

              <div className="card">
                <i className="fa fa-bars fa-2x text-green"></i>
                <div className="card_inner">
                  <h5 className="text-primary-p">Média Produção</h5>
                  <span className="font-bold text-title">40</span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </main>
    </div>
  );
};

export default MainDashBoard;
