import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";
import { useEffect, useState } from "react";
import {
  Button,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Table,
  Row
} from "reactstrap";
import HeaderPlatform from "../components/HeaderPlatform/HeaderPlatform";

function Product() {
  const baseUrl = "https://localhost:5001/api/Products";

  const [data, setData] = useState([]);
  const [modalIncluir, setModalIncluir] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modalExcluir, setModalExcluir] = useState(false);
  const [modalFiltro, setModalFiltro] = useState(false);

  const [productselect, setProductSelect] = useState({
    name: "",
    type: "",
  });

  const [productselectBycode, setProductSelectByCode] = useState({
    code: "",
  });

  const selectProduct = (product, opcao) => {
    setProductSelect(product);
    opcao === "Editar" ? abrirFecharModalEditar() : abrirFecharModalExcluir();
  };

  const abrirFecharModalIncluir = () => {
    setModalIncluir(!modalIncluir);
  };

  const abrirFecharModalEditar = () => {
    setModalEditar(!modalEditar);
  };

  const abrirFecharModalExcluir = () => {
    setModalExcluir(!modalExcluir);
  };

  const abrirFecharModalFiltro = () => {
    setModalFiltro(!modalFiltro);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setProductSelect({
      ...productselect,
      [name]: value,
    });
    console.log(productselect);
  };

  const handleChangeGet = (e) => {
    const { name, value } = e.target;
    setProductSelectByCode({
      ...productselectBycode,
      [name]: value,
    });
    console.log(productselectBycode);
  };

  const pedidoGetByCode = async () => {
    await axios
      .get(baseUrl + "/" + productselectBycode.code)
      .then((response) => {
        console.log(response);
        console.log(response.data);
        setData([response.data]);
        abrirFecharModalFiltro();
      })
      .catch((error) => {
        console.log(error);
      });
  };

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

  const pedidoPost = () => {
    axios
      .post(baseUrl, productselect)
      .then((response) => {
        console.log({
          response,
        });
        setData(data.concat(response.data));
        abrirFecharModalIncluir();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const pedidoPut = async () => {
    await axios
      .put(baseUrl, productselect)
      .then((response) => {
        const update = [...data];
        update[update.map((u) => u.code).indexOf(response.data.code)] =
          response.data;
        setData(update);
        abrirFecharModalEditar();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const pedidoDelete = async () => {
    await axios
      .delete(baseUrl + "/" + productselect.code)
      .then((response) => {
        setData(
          data.filter((employeer) => employeer.code !== productselect.code)
        );
        abrirFecharModalExcluir();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  useEffect(() => {
    pedidoGet();
  }, []);

  return (
    <div>
      <HeaderPlatform />
      <div className="container">
        <h2>Produtos</h2>
        <Button
          color="primary
        "
          outline
          className="btn"
          onClick={() => abrirFecharModalIncluir()}
        >
          Cadastrar Novo
        </Button>{" "}
        <Button
          color="primary
        "
          outline
          className="btn"
          onClick={() => abrirFecharModalFiltro()}
        >
          Buscar Por Codigo
        </Button>{" "}
        <div>
          <br />
        </div>
        <Row md="12" sm="2" xs="1">
          <Table bordered hover responsive size="sm">
            <thead className="table-warning">
              <tr>
                <th scope="col">Codigo</th>
                <th scope="col">Nome do produto</th>
                <th scope="col">Tipo</th>
                <th scope="col">Operação</th>
              </tr>
            </thead>
            <tbody className="table-light">
              {data.map((product) => (
                <tr key={product.code}>
                  <td>{product.code}</td>
                  <td>{product.name}</td>
                  <td>{product.type}</td>
                  <td>
                    <button
                      className="btn btn-primary"
                      onClick={() => selectProduct(product, "Editar")}
                    >
                      Editar
                    </button>
                    <button
                      className="btn btn-danger"
                      onClick={() => selectProduct(product, "Excluir")}
                    >
                      Excluir
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Row>
        <Modal isOpen={modalIncluir}>
          <ModalHeader>Incluir Produto</ModalHeader>
          <ModalBody>
            <div className="form-group">
              <label>Nome:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="name"
                onChange={handleChange}
              ></input>
              <label htmlFor="type">Tipo:</label>
              <br />
              <select
                type="text"
                className="form"
                name="type"
                onChange={handleChange}
              >
                <option value="">
                  <em></em>
                </option>
                <option>C1</option>
                <option>C2</option>
                <option>C3</option>
                <option>C4</option>
                <option>C5</option>
                <option>C6</option>
              </select>
            </div>
          </ModalBody>
          <ModalFooter>
            <button className="btn btn-primary" onClick={() => pedidoPost()}>
              {" "}
              Incluir
            </button>
            <button
              className="btn btn-danger"
              onClick={() => abrirFecharModalIncluir()}
            >
              Cancelar
            </button>
          </ModalFooter>
        </Modal>
        <Modal isOpen={modalEditar}>
          <ModalHeader>Editar Produto</ModalHeader>
          <ModalBody>
            <div className="form-group">
              <label>Codigo:</label>
              <input
                type="text"
                className="form-control"
                readOnly
                value={productselect && productselect.code}
              />
              <br />
              <label>Nome:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="name"
                onChange={handleChange}
                value={productselect && productselect.name}
              ></input>
              <label htmlFor="type">Tipo:</label>
              <br />
              <select
                type="text"
                className="form"
                name="type"
                onChange={handleChange}
                value={productselect && productselect.type}
              >
                <option value="">
                  <em></em>
                </option>
                <option>C1</option>
                <option>C2</option>
                <option>C3</option>
                <option>C4</option>
                <option>C5</option>
                <option>C6</option>
              </select>
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
        <Modal isOpen={modalFiltro}>
          <ModalHeader>Buscar Produto</ModalHeader>
          <ModalBody>
            <div className="form-group">
              <label>Codigo:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="code"
                onChange={handleChangeGet}
              ></input>
            </div>
          </ModalBody>

          <ModalFooter>
            <button
              className="btn btn-primary"
              onClick={() => pedidoGetByCode()}
            >
              {" "}
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
        <Modal isOpen={modalExcluir}>
          <ModalBody>
            Confirma a exclusão deste (a) Produto :{" "}
            {productselect && productselect.name} ?
          </ModalBody>
          <ModalFooter>
            <button className="btn btn-primary" onClick={() => pedidoDelete()}>
              {"  "}
              Sim
            </button>
            <button
              className="btn btn-danger"
              onClick={() => abrirFecharModalExcluir()}
            >
              Não
            </button>
          </ModalFooter>
        </Modal>
      </div>
    </div>
  );
}

export default Product;
