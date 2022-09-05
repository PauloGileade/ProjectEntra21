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
    window.location.href = "/order/" + celula + "/" + dataDados;
  }

  const pedidoGet = async () => {
    await axios
      .get(baseUrl)
      .then((response) => {
        console.log(response);
        setData(response.data.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const pedidoGetByCell = async () => {
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
    pedidoGetByCell();
    pedidoGet();
  }, []);

  let sumEnter = 0;
  let sumFinished = 0;
  let average = 0;
  let maior = 0;
  let employeer1;

  data.forEach((order) => {
    if (order.phase === "Inicial") {
      sumEnter += order.amountEnter;
    }
    if (order.phase === "Final") {
      sumFinished += order.amountFinished;
    }
    average = sumFinished / data.length;
  });

  data.forEach((order) => {
    if (order.amountFinished > maior) {
      maior = order.amountFinished;
      employeer1 =
        order.nameEmployeer +
        " / Celula " +
        order.codeCell +
        "/ " +
        maior +
        " Bag";
    }
  });

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
              <h1>Filtrar Ordens</h1>
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
          <div className="charts">
            <div className="charts__left">
              <div className="charts__left__title">
                <div>
                  <h2>1°</h2>
                  <h5 className="text-primary-p">{employeer1}</h5>
                </div>
                <i class="fa-solid fa-medal"></i>
              </div>
            </div>
          </div>
          <br />
          <h2>Painel De Ordens</h2>
          <Table bordered responsive size="sm">
            <thead className="table__order">
              <tr align="center">
                <th>Codigo celula</th>
                <th>Codigo produto</th>
                <th>Nome produto</th>
                <th>Matricula funcionario</th>
                <th>Nome funcionario</th>
                <th>Quantidade entrada</th>
                <th>Quantidade saida</th>
                <th>Data criação</th>
                <th>Fase</th>
              </tr>
            </thead>
            <tbody>
              {data.map((order) => (
                <tr
                  className="table__painel"
                  align="center"
                  key={order.codeCell}
                >
                  <td>{order.codeCell}</td>
                  <td>{order.codeProduct}</td>
                  <td>{order.nameProduct}</td>
                  <td>{order.registerEmployeer}</td>
                  <td>{order.nameEmployeer}</td>
                  <td>{order.amountEnter}</td>
                  <td>{order.amountFinished}</td>
                  <td>{order.creatAt}</td>
                  <td>{order.phase}</td>
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
                <div className="card_inner">
                  <h5 className="text-primary-p">Total De Ordens</h5>
                  <span className="font-bold text-title">{data.length}</span>
                </div>
              </div>

              <div className="card">
                <div className="card_inner">
                  <h5 className="text-primary-p">Total De Entrada</h5>
                  <span className="font-bold text-title">{sumEnter}</span>
                </div>
              </div>

              <div className="card">
                <div className="card_inner">
                  <h5 className="text-primary-p">Total De Saida</h5>
                  <span className="font-bold text-title">{sumFinished}</span>
                </div>
              </div>

              <div className="card">
                <div className="card_inner">
                  <h5 className="text-primary-p">Média Produção</h5>
                  <span className="font-bold text-title">
                    {average.toPrecision(2)}
                  </span>
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