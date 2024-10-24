create database SCPComputershow;

use SCPComputershow;

CREATE TABLE tb_Productos (
    producto_id INT IDENTITY(1,1) PRIMARY KEY, 
    nombre VARCHAR(255) NOT NULL, 
    descripcion TEXT, 
    precio DECIMAL(10, 2) NOT NULL, 
    stock INT NOT NULL, 
    categoria_id INT FOREIGN KEY REFERENCES tb_Categorias(categoria_id), 
    marca_id INT FOREIGN KEY REFERENCES tb_Marca(marca_id) -- Nueva relación con tb_Marca
);


CREATE TABLE tb_Categorias (
    categoria_id INT IDENTITY(1,1) PRIMARY KEY, 
    nombre VARCHAR(100) NOT NULL, 
    descripcion TEXT
);


CREATE TABLE tb_Clientes (
    cliente_id INT IDENTITY(1,1) PRIMARY KEY, 
    nombre VARCHAR(255) NOT NULL, 
    email VARCHAR(255), 
    telefono VARCHAR(20), 
    direccion VARCHAR(255), 
    ciudad VARCHAR(100), 
    pais VARCHAR(100), 
    dni VARCHAR(15), 
    ruc VARCHAR(15), 
    distrito VARCHAR(100)
);

CREATE TABLE tb_Pedidos (
    pedido_id INT IDENTITY(1,1) PRIMARY KEY, 
    fecha_pedido DATETIME NOT NULL, 
    cliente_id INT FOREIGN KEY REFERENCES tb_Clientes(cliente_id) -- Relación con tb_Clientes
);



CREATE TABLE tb_Detalles_Pedido (
    detalle_pedido_id INT IDENTITY(1,1) PRIMARY KEY, 
    pedido_id INT FOREIGN KEY REFERENCES tb_Pedidos(pedido_id), 
    producto_id INT FOREIGN KEY REFERENCES tb_Productos(producto_id), 
    cantidad INT NOT NULL, 
    precio_unitario DECIMAL(10, 2) NOT NULL
);


CREATE TABLE tb_Pagos (
    pago_id INT IDENTITY(1,1) PRIMARY KEY, 
    pedido_id INT FOREIGN KEY REFERENCES tb_Pedidos(pedido_id), 
    metodo_pago VARCHAR(50), 
    monto DECIMAL(10, 2) NOT NULL, 
    fecha_pago DATETIME NOT NULL
);


CREATE TABLE tb_Inventario (
    inventario_id INT IDENTITY(1,1) PRIMARY KEY, 
    producto_id INT FOREIGN KEY REFERENCES tb_Productos(producto_id), 
    cantidad INT NOT NULL, 
    tipo_movimiento VARCHAR(50) NOT NULL, -- Entrada o salida
    fecha_movimiento DATETIME NOT NULL
);

CREATE TABLE tb_Ventas (
    venta_id INT IDENTITY(1,1) PRIMARY KEY, 
    pedido_id INT FOREIGN KEY REFERENCES tb_Pedidos(pedido_id), 
    empleado_id INT FOREIGN KEY REFERENCES tb_Empleados(empleado_id), 
    fecha_venta DATETIME NOT NULL, 
    monto_total DECIMAL(10, 2) NOT NULL
);

CREATE TABLE tb_Usuarios (
    usuario_id INT IDENTITY(1,1) PRIMARY KEY, 
    nombre_usuario VARCHAR(100) NOT NULL, 
    email VARCHAR(255), 
    password VARCHAR(255) NOT NULL, 
    rol_id INT FOREIGN KEY REFERENCES tb_Roles(rol_id), 
    empleado_id INT FOREIGN KEY REFERENCES tb_Empleados(empleado_id) -- Opcional
);


CREATE TABLE tb_Roles (
    rol_id INT IDENTITY(1,1) PRIMARY KEY, 
    nombre VARCHAR(100) NOT NULL, 
    descripcion TEXT
);


CREATE TABLE tb_Empleados (
    empleado_id INT IDENTITY(1,1) PRIMARY KEY, 
    nombre VARCHAR(255) NOT NULL, 
    email VARCHAR(255), 
    telefono VARCHAR(20), 
    direccion VARCHAR(255), 
    ciudad VARCHAR(100), 
    fecha_contratacion DATE NOT NULL
);



CREATE TABLE tb_Marca (
    marca_id INT IDENTITY(1,1) PRIMARY KEY, 
    nombre VARCHAR(100) NOT NULL, 
    descripcion TEXT
);


CREATE TABLE tb_Factura (
    factura_id INT IDENTITY(1,1) PRIMARY KEY, 
    pedido_id INT FOREIGN KEY REFERENCES tb_Pedidos(pedido_id), 
    cliente_id INT FOREIGN KEY REFERENCES tb_Clientes(cliente_id), -- Relación con tb_Clientes
    numero_factura VARCHAR(50) NOT NULL, 
    fecha_emision DATETIME NOT NULL, 
    monto_total DECIMAL(10,2) NOT NULL
);
