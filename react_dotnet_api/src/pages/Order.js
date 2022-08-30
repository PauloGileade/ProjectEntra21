import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";
import { useEffect, useState } from "react";
import { Table } from "reactstrap";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { useParams } from "react-router-dom";
import HeaderPlatform from "../components/HeaderPlatform/HeaderPlatform";

function Order() {
  const baseUrl = "https://localhost:5001/api/Orders";

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
         console.log(error);
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
         console.log(error);
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
         console.log(error);
       });
   };

   const pedidoPut = async () => {
     orderselect.registerEmployeer = parseInt(orderselect.registerEmployeer);
     orderselect.codeProduct = parseInt(orderselect.codeProduct);
     orderselect.amountEnter = parseInt(orderselect.amountEnter);
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
         console.log(error);
       });
   };

  useEffect(() => {
    pedidoGet();
    pedidoGetByRegister();
    pedidoGetByCodeProduct();
  }, []);

  return (
    <div>
      <HeaderPlatform />
      <div className="container">
        <br/>
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
              <th>Operação</th>
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
                <td>
                  <button
                    className="btn btn-primary"
                    onClick={() => selectOrder(order, "Editar")}
                  >
                    Editar
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
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
              <br />
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
                value={orderselect && orderselect.amountEnter}
              ></input>
            </div>
          </ModalBody>
          <ModalFooter>
            <button className="btn btn-primary" onClick={() => pedidoPut()}>
              {" "}
              Editar
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
    </div>
  );
}

export default Order;
