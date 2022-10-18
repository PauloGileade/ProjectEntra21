import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";
import { useEffect, useState } from "react";
import { Table } from "reactstrap";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { useParams } from "react-router-dom";
import HeaderPlatform from "../components/HeaderPlatform/HeaderPlatform";

function Order() {
  const baseUrl = "https://192.168.1.7:5001/api/Orders";

  const [data, setData] = useState([]);
  const [modalEditar, setModalEditar] = useState(false);
  const [modalExcluir, setModalExcluir] = useState(false);

  let codecell = useParams().codeCell;
  let date = useParams().date;

  let register = useParams().register;

  let codeProduct = useParams().codeProduct;
  let dateStart = useParams().dateStart;
  let dateEnd = useParams().dateEnd;

  const [orderselect, setOrderSelect] = useState({
    registerEmployeer: "",
    codeProduct: "",
    phase: "",
    amountEnter: "",
  });

  const selectOrder = (order, opcao) => {
    setOrderSelect(order);
    opcao === "Editar" ? abrirFecharModalEditar() : abrirFecharModalExcluir();
  };

  const abrirFecharModalEditar = () => {
    setModalEditar(!modalEditar);
  };

  const abrirFecharModalExcluir = () => {
    setModalExcluir(!modalExcluir);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setOrderSelect({
      ...orderselect,
      [name]: value,
    });
    console.log(orderselect);
  };

  const pedidoGet = async () => {
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

  const pedidoGetByRegister = async () => {
    await axios
      .get(baseUrl + "/" + dateStart + "/" + dateEnd + "/" + register)
      .then((response) => {
        console.log(response);
        setData(response.data.data);
      })
      .catch((error) => {
        console.log(error.response.data);
      });
  };

  const pedidoGetByCodeProduct = async () => {
    await axios
      .get(
        baseUrl +
          "/" +
          register +
          "/" +
          codeProduct +
          "/" +
          dateStart +
          "/" +
          dateEnd
      )
      .then((response) => {
        console.log(response);
        setData([response.data]);
      })
      .catch((error) => {
        console.log(error.response.data);
      });
  };

  const pedidoPut = async () => {
    orderselect.registerEmployeer = parseInt(orderselect.registerEmployeer);
    orderselect.codeProduct = parseInt(orderselect.codeProduct);
    orderselect.amountEnter = parseInt(orderselect.amountEnter);
    orderselect.phase = parseInt(orderselect.phase);
    await axios
      .put(baseUrl, orderselect)
      .then((response) => {
        const update = [...data];
        update[update.map((u) => u.codeCell).indexOf(response.data.codeCell)] =
          response.data;
        setData(update);
        abrirFecharModalEditar();
      })
      .catch((error) => {
        console.log(error.response.data);
        alert(error.response.data);
      });
  };

  useEffect(() => {
    pedidoGet();
    pedidoGetByRegister();
    pedidoGetByCodeProduct();
  }, []);

  let sumEnter = 0;
  let sumFinished = 0;

  data.forEach((order) => {
    if (order.phase === "Inicial") {
      sumEnter += order.amountEnter;
    }
    if (order.phase === "Final") {
      sumFinished += order.amountFinished;
    }
  });

  data.forEach((order) => {
    if (order.amountFinished >= 180) {
      order.goal = "Alcançada";
    } else {
      order.goal = "Não Alcançada";
    }
  });

  return (
    <div>
      <HeaderPlatform />
      <main className="main__global">
        <div>
          <br />
          <h2>Painel De Ordens</h2>
          <Table bordered hover responsive size="sm">
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
                <th>Adicionar entrada</th>
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
                  <td>
                    <button
                      className="btn btn-primary"
                      onClick={() => selectOrder(order, "Editar")}
                    >
                      Adicionar
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
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

          <Modal isOpen={modalEditar}>
            <ModalHeader>Editar Ordem</ModalHeader>
            <ModalBody>
              <div className="form-group">
                <label>Matricula Do Funcionario:</label>
                <input
                  type="text"
                  className="form-control"
                  disabled
                  value={orderselect && orderselect.registerEmployeer}
                />
                <label>Codigo Do Produto:</label>
                <br />
                <input
                  type="text"
                  className="form-control"
                  disabled
                  onChange={handleChange}
                  value={orderselect && orderselect.codeProduct}
                ></input>
                <label>Quantidade De Entrada:</label>
                <br />
                <input
                  type="text"
                  className="form-control"
                  name="amountEnter"
                  onChange={handleChange}
                ></input>
                <label htmlFor="phase">Fase:</label>
                <br />
                <select
                  type="text"
                  className="form"
                  name="phase"
                  onChange={handleChange}
                >
                  <option value="">
                    <em></em>
                  </option>
                  <option>1</option>
                  <option>2</option>
                  <option>3</option>
                </select>
              </div>
            </ModalBody>
            <ModalFooter>
              <button className="btn btn-primary" onClick={() => pedidoPut()}>
                {" "}
                Adicionar
              </button>
              <button
                className="btn btn-danger"
                onClick={() => abrirFecharModalEditar()}
              >
                Cancelar
              </button>
            </ModalFooter>
          </Modal>
        </div>
      </main>
    </div>
  );
}

export default Order;
