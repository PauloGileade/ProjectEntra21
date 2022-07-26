import axios from "axios";
import { useState, useEffect } from "react";
import { Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { dropdown } from "bootstrap";
import Button from "@mui/material/Button";

function HeaderPlatform() {
  const baseUrl = "https://192.168.1.7:5001/api/Orders";
  const baseUrlCellEmployeer = "https://192.168.1.7:5001/api/CellEmployeers";
  const baseUrlTotalPartial = "https://192.168.1.7:5001/api/TotalPartials";

  const [data, setData] = useState([]);
  const [modalIncluir, setModalIncluir] = useState(false);
  const [modalIncluirCellEmployeer, setModalIncluirCellEmployeer] =
    useState(false);
  const [modalFiltroByCell, setModalFiltroByCell] = useState(false);
  const [modalFiltroByRegister, setModalFiltroByRegister] = useState(false);
  const [modalFiltroByCodeProduct, setModalFiltroByCodeProduct] =
    useState(false);
  const [modalFiltroCellEmployeer, setModalFiltroCellEmployeer] =
    useState(false);
  const [dataDadosStart, setDataDadosStart] = useState("");
  const [dataDadosEnd, setDataDadosEnd] = useState("");

  const [orderselectOrdemIntermediaria, setOrderSelectOrdemIntermediaria] =
    useState({
      codeCell: "",
      phaseOrderTotalPartial: "",
    });

  let phaseSelect = orderselectOrdemIntermediaria.phaseOrderTotalPartial;

  const [orderselect, setOrderSelect] = useState({
    registerEmployeer: "",
    codeProduct: "",
    phase: "",
    amountEnter: "",
  });

  const [cellEmployeerselect, setCellEmployeerSelect] = useState({
    codeCell: "",
    registerEmployeer: "",
    phase: "",
  });

  const [orderByCellselect, setOrderByCellSelect] = useState({
    codeCell: "",
  });

  const [orderByRegisterselect, setOrderByRegisterSelect] = useState({
    register: "",
  });

  const [orderByCodeProductselect, setOrderByCodeProductSelect] = useState({
    register: "",
    codeProduct: "",
  });

  const [orderCellEmployeerselect, setOrderCellEmployeerSelect] = useState({
    codeCell: "",
  });

  const abrirFecharModalIncluir = () => {
    setModalIncluir(!modalIncluir);
  };

  const abrirFecharModalIncluirCellEmployeer = () => {
    setModalIncluirCellEmployeer(!modalIncluirCellEmployeer);
  };

  const abrirFecharModalFiltro = () => {
    setModalFiltroByCell(!modalFiltroByCell);
  };

  const abrirFecharModalFiltroByRegister = () => {
    setModalFiltroByRegister(!modalFiltroByRegister);
  };

  const abrirFecharModalFiltroByCodeProduct = () => {
    setModalFiltroByCodeProduct(!modalFiltroByCodeProduct);
  };

  const abrirFecharModalFiltroCellEmployeer = () => {
    setModalFiltroCellEmployeer(!modalFiltroCellEmployeer);
  };

  const setDataStart = (value) => {
    setDataDadosStart(value.split("/").reverse().join("-"));
  };

  const setDataEnd = (value) => {
    setDataDadosEnd(value.split("/").reverse().join("-"));
  };

  function redirect() {
    window.location.href =
      "/order/" + orderByCellselect.codeCell + "/" + dataDadosStart;
  }

  function redirectCellEmployeer() {
    window.location.href =
      "/cellemployeer/" +
      orderCellEmployeerselect.codeCell +
      "/" +
      dataDadosStart;
  }

  function redirectByRegister() {
    window.location.href =
      "/order/" +
      dataDadosStart +
      "/" +
      dataDadosEnd +
      "/" +
      orderByRegisterselect.register;
  }

  function redirectByCodeProduct() {
    window.location.href =
      "/order/" +
      orderByCodeProductselect.register +
      "/" +
      orderByCodeProductselect.codeProduct +
      "/" +
      dataDadosStart +
      "/" +
      dataDadosEnd;
  }

  const handleChange = (e) => {
    const { name, value } = e.target;
    setOrderSelect({
      ...orderselect,
      [name]: value,
    });
    console.log(orderselect);
  };

  const handleChangeOrdemIntermediaria = (e) => {
    const { name, value } = e.target;
    setOrderSelectOrdemIntermediaria({
      ...orderselectOrdemIntermediaria,
      [name]: value,
    });
    console.log(orderselectOrdemIntermediaria);
  };

  const handleChangeCellEmployeer = (e) => {
    const { name, value } = e.target;
    setCellEmployeerSelect({
      ...cellEmployeerselect,
      [name]: value,
    });
    console.log(cellEmployeerselect);
  };

  const handleChangeGet = (e) => {
    const { name, value } = e.target;
    setOrderByCellSelect({
      ...orderByCellselect,
      [name]: value,
    });
    console.log(orderByCellselect);
  };

  const handleChangeGetByRegister = (e) => {
    const { name, value } = e.target;
    setOrderByRegisterSelect({
      ...orderByRegisterselect,
      [name]: value,
    });
    console.log(orderByRegisterselect);
  };

  const handleChangeGetByCodeProduct = (e) => {
    const { name, value } = e.target;
    setOrderByCodeProductSelect({
      ...orderByCodeProductselect,
      [name]: value,
    });
    console.log(orderByCodeProductselect);
  };

  const handleChangeGetCellEmployeer = (e) => {
    const { name, value } = e.target;
    setOrderCellEmployeerSelect({
      ...orderCellEmployeerselect,
      [name]: value,
    });
    console.log(orderCellEmployeerselect);
  };

  const pedidoPostOrder = () => {
    orderselect.phase = parseInt(orderselect.phase);
    axios
      .post(baseUrl, orderselect)
      .then((response) => {
        console.log({
          response,
        });
        setData(data.concat(response.data));
        abrirFecharModalIncluir();
      })
      .catch((error) => {
        console.log(error.response.data);
        alert(error.response.data);
      });
  };

  const pedidoPostCellEmployeer = () => {
    cellEmployeerselect.phase = parseInt(cellEmployeerselect.phase);
    axios
      .post(baseUrlCellEmployeer, cellEmployeerselect)
      .then((response) => {
        console.log({
          response,
        });
        setData(data.concat(response.data));
        abrirFecharModalIncluirCellEmployeer();
      })
      .catch((error) => {
          console.log(error.response.data);
          alert(error.response.data);
      });
  };

  const GetTotalPartialByCell = async () => {
    await axios
      .get(
        baseUrlTotalPartial +
          "/" +
          phaseSelect +
          "/" +
          orderselectOrdemIntermediaria.codeCell
      )
      .then((response) => {
        console.log(response);
        setData([response.data]);
      })
      .catch((error) => {
         console.log(error.response.data);
      });
  };

  useEffect(() => {
    GetTotalPartialByCell();
  }, []);

  return (
    <div>
      <nav className="navbar navbar-expand-lg navbar-warning bg-warning">
        <div className="container-fluid">
          <a className="navbar-brand" href="/employeer">
            <strong>Plataforma CTA</strong>
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarColor01"
            aria-controls="navbarColor01"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarColor01">
            <ul className="navbar-nav me-auto">
              <li className="nav-item">
                <a className="nav-link active" href="/dashboard">
                  <strong>Painel CTA</strong>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link active" href="/employeer">
                  <strong>Funcionarios</strong>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link active" href="/product">
                  <strong>Produtos</strong>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link active" href="/cell">
                  <strong>Celulas</strong>
                </a>
              </li>
              <li className="nav-item dropdown">
                <a
                  className="nav-link active dropdown"
                  data-bs-toggle="dropdown"
                  href="#"
                  role="button"
                  aria-haspopup="true"
                  aria-expanded="false"
                >
                  <strong>Ordens</strong>
                </a>
                <div className="dropdown-menu">
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalFiltro()}
                  >
                    Buscar Por Celula
                  </a>
                  <div className="dropdown-divider"></div>
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalFiltroByRegister()}
                  >
                    Buscar Por Matricula
                  </a>
                  <div className="dropdown-divider"></div>
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalFiltroByCodeProduct()}
                  >
                    Buscar Por Matricula/Produto
                  </a>
                  <div className="dropdown-divider"></div>
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalIncluir()}
                  >
                    Cadastrar Nova Ordem
                  </a>
                </div>
              </li>
              <li className="nav-item dropdown">
                <a
                  className="nav-link active dropdown"
                  data-bs-toggle="dropdown"
                  href="#"
                  role="button"
                  aria-haspopup="true"
                  aria-expanded="false"
                >
                  <strong>Operação</strong>
                </a>
                <div className="dropdown-menu">
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalFiltroCellEmployeer()}
                  >
                    Buscar Por Celula
                  </a>
                  <div className="dropdown-divider"></div>
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalIncluirCellEmployeer()}
                  >
                    Cadastrar Nova
                  </a>
                </div>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      <Modal isOpen={modalIncluir}>
        <ModalHeader>Buscar Total De Saida</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <td>
              <label>Celulá </label>
              <select
                type="text"
                className="form"
                name="codeCell"
                onChange={handleChangeOrdemIntermediaria}
              >
                <option value="">
                  <em></em>
                </option>
                <option>1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
                <option>5</option>
                <option>6</option>
              </select>
              <label>Fase</label>
              <select
                type="text"
                className="form"
                name="phaseOrderTotalPartial"
                onChange={handleChangeOrdemIntermediaria}
              >
                <option value="">
                  <em></em>
                </option>
                <option>1</option>
                <option>2</option>
              </select>
              <Button
                variant="contained"
                onClick={() => GetTotalPartialByCell()}
              >
                Buscar
              </Button>
            </td>
            <br />
            <h5>Cadastrar Nova Ordem</h5>
            <label>Matricula Do Funcionario:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="registerEmployeer"
              onChange={handleChange}
            ></input>
            <label>Codigo Do Produto:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="codeProduct"
              onChange={handleChange}
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
            <div>
              <br />
            </div>
            <p>
              Total Disponivel:{" "}
              {data.map((totalPartial) => (
                <tr
                  className="table__painel"
                  align="center"
                  key={totalPartial.codeCell}
                >
                  <td>{totalPartial.totalPhaseExit}</td>
                </tr>
              ))}
            </p>
          </div>
        </ModalBody>

        <ModalFooter>
          <button className="btn btn-primary" onClick={() => pedidoPostOrder()}>
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

      <Modal isOpen={modalIncluirCellEmployeer}>
        <ModalHeader>Incluir Nova</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <label>Celula:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="codeCell"
              onChange={handleChangeCellEmployeer}
            ></input>
            <label>Matricula:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="registerEmployeer"
              onChange={handleChangeCellEmployeer}
            ></input>
            <label htmlFor="phase">Fase:</label>
            <br />
            <select
              type="text"
              className="form"
              name="phase"
              onChange={handleChangeCellEmployeer}
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
          <button
            className="btn btn-primary"
            onClick={() => pedidoPostCellEmployeer()}
          >
            {" "}
            Incluir
          </button>
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalIncluirCellEmployeer()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalFiltroByCell}>
        <ModalHeader>Filtrar</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <label>Celula:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="codeCell"
              onChange={handleChangeGet}
            ></input>
          </div>
          <div className="form-group">
            <label>Data:</label>
            <br />
            <input
              type="date"
              className="form-control"
              name="data"
              onChange={(e) => setDataStart(e.target.value)}
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

      <Modal isOpen={modalFiltroByRegister}>
        <ModalHeader>Filtrar</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <div className="form-group">
              <label>Data Inicial:</label>
              <br />
              <input
                type="date"
                className="form-control"
                name="data"
                onChange={(e) => setDataStart(e.target.value)}
              ></input>
            </div>
            <div className="form-group">
              <label>Data Final:</label>
              <br />
              <input
                type="date"
                className="form-control"
                name="data"
                onChange={(e) => setDataEnd(e.target.value)}
              ></input>
            </div>
            <label>Matricula:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="register"
              onChange={handleChangeGetByRegister}
            ></input>
          </div>
        </ModalBody>

        <ModalFooter>
          <button
            className="btn btn-primary"
            onClick={() => redirectByRegister()}
          >
            Buscar
          </button>
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalFiltroByRegister()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalFiltroByCodeProduct}>
        <ModalHeader>Filtrar</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <div className="form-group">
              <label>Matricula:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="register"
                onChange={handleChangeGetByCodeProduct}
              ></input>
              <label>Codigo Do Produto:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="codeProduct"
                onChange={handleChangeGetByCodeProduct}
              ></input>
              <label>Data Inicial:</label>
              <br />
              <input
                type="date"
                className="form-control"
                name="data"
                onChange={(e) => setDataStart(e.target.value)}
              ></input>
            </div>
            <div className="form-group">
              <label>Data Final:</label>
              <br />
              <input
                type="date"
                className="form-control"
                name="data"
                onChange={(e) => setDataEnd(e.target.value)}
              ></input>
            </div>
          </div>
        </ModalBody>

        <ModalFooter>
          <button
            className="btn btn-primary"
            onClick={() => redirectByCodeProduct()}
          >
            Buscar
          </button>
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalFiltroByCodeProduct()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalFiltroCellEmployeer}>
        <ModalHeader>Filtrar</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <div className="form-group">
              <label>Celula:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="codeCell"
                onChange={handleChangeGetCellEmployeer}
              ></input>
              <label>Data Inicial:</label>
              <br />
              <input
                type="date"
                className="form-control"
                name="data"
                onChange={(e) => setDataStart(e.target.value)}
              ></input>
            </div>
          </div>
        </ModalBody>

        <ModalFooter>
          <button
            className="btn btn-primary"
            onClick={() => redirectCellEmployeer()}
          >
            Buscar
          </button>
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalFiltroCellEmployeer()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>
    </div>
  );
}

export default HeaderPlatform;
