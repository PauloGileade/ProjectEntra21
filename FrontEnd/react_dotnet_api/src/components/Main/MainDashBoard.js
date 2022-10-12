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
import Order from "../../pages/Order";

const MainDashBoard = () => {
  const [data, setData] = useState([]);
  const [modalFiltro, setModalFiltro] = useState(false);
  const [celula, setCelula] = useState("");
  const [dataDados, setDataDados] = useState("");

  const baseUrl = "https://192.168.1.7:5001/api/Orders";

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
         console.log(error.response.data);
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
         console.log(error.response.data);
      });
  };

  useEffect(() => {
    pedidoGetByCell();
    pedidoGet();
  }, []);

  let sumEnter = 0;
  let sumFinished = 0;
  let maiorProdução = 0;
  let employeerNumberOne = "";
  let largerPhaseInitial = 0;
  let largerPhaseIntermediary = 0;
  let largerPhaseFinal = 0;
  let NumberOneInitial = "";
  let NumberOneIntermediary = "";
  let NumberOneFinal = "";

  data.forEach((order) => {
    if (order.amountFinished >= 180) {
      order.goal = "Alcançada";
    } else {
      order.goal = "Não Alcançada";
    }
  });

  data.forEach((order) => {
    if (order.phase === "Inicial") {
      sumEnter += order.amountEnter;
    }
    if (order.phase === "Final") {
      sumFinished += order.amountFinished;
    }
  });

  data.forEach((order) => {
    if (order.amountFinished > maiorProdução) {
      maiorProdução = order.amountFinished;
      employeerNumberOne =
        order.nameEmployeer +
        "/ Celula " +
        order.codeCell +
        "/ fase " +
        order.phase +
        "/ " +
        maiorProdução +
        " Bag";
    }
    if (
      order.amountFinished > largerPhaseInitial &&
      order.phase === "Inicial"
    ) {
      largerPhaseInitial = order.amountFinished;
      NumberOneInitial =
        order.nameEmployeer +
        "/ Celula " +
        order.codeCell +
        "/ fase " +
        order.phase +
        "/ " +
        largerPhaseInitial +
        " Bag";
    }
    if (
      order.amountFinished > largerPhaseIntermediary &&
      order.phase === "Intermediaria"
    ) {
      largerPhaseIntermediary = order.amountFinished;
      NumberOneIntermediary =
        order.nameEmployeer +
        "/ Celula " +
        order.codeCell +
        "/ fase " +
        order.phase +
        "/ " +
        largerPhaseIntermediary +
        " Bag";
    }
    if (order.amountFinished > largerPhaseFinal && order.phase === "Final") {
      largerPhaseFinal = order.amountFinished;
      NumberOneFinal =
        order.nameEmployeer +
        "/ Celula " +
        order.codeCell +
        "/ fase " +
        order.phase +
        "/ " +
        largerPhaseFinal +
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
            <div className="button__main">
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
            </div>
          </Stack>
          <div className="charts">
            <div className="charts__left">
              <div className="charts__left__title">
                <div>
                  <h2>Maior Produção</h2>
                  <h5 className="text-primary-p">{employeerNumberOne}</h5>
                </div>
                <i className="fa-solid fa-medal"></i>
              </div>
            </div>
            <div className="charts__left">
              <div className="charts__left__title">
                <div>
                  <h2>1° Fase Inicial</h2>
                  <h5 className="text-primary-p">{NumberOneInitial}</h5>
                </div>
                <i className="fa-solid fa-medal"></i>
              </div>
            </div>
            <div className="charts__left">
              <div className="charts__left__title">
                <div>
                  <h2>1° Fase Intermediaria</h2>
                  <h5 className="text-primary-p">{NumberOneIntermediary}</h5>
                </div>
                <i className="fa-solid fa-medal"></i>
              </div>
            </div>
            <div className="charts__left">
              <div className="charts__left__title">
                <div>
                  <h2>1° Fase Final</h2>
                  <h5 className="text-primary-p">{NumberOneFinal}</h5>
                </div>
                <i className="fa-solid fa-medal"></i>
              </div>
            </div>
          </div>

          <br />
          <h2>Painel De Ordens</h2>
          <Table bordered responsive size="sm">
            <thead className="table__order">
              <tr align="center">
                <th>Celula</th>
                <th>Codigo produto</th>
                <th>Nome produto</th>
                <th>Matricula</th>
                <th>Nome funcionario</th>
                <th>Quantidade entrada</th>
                <th>Quantidade saida</th>
                <th>Data criação</th>
                <th>Fase</th>
                <th>Meta</th>
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
                  <td>{order.goal}</td>
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
            </div>
          </div>
        </div>
      </main>
    </div>
  );
};

export default MainDashBoard;
