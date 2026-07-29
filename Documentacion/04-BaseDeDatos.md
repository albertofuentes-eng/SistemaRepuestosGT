# Diseño de la Base de Datos

## Objetivo

Diseñar una base de datos segura, organizada y escalable para administrar un negocio de venta de repuestos para motocicletas, carros y tuc tuc.

La base de datos será creada posteriormente mediante Entity Framework Core y Migraciones.

---

# Tablas del Sistema

## Seguridad

- Empresa
- Rol
- Usuario

---

## Catálogos

- Categoria
- Marca
- TipoVehiculo
- Proveedor

---

## Inventario

- Producto
- MovimientoInventario

---

## Compras

- Compra
- DetalleCompra

---

## Ventas

- Cliente
- Venta
- DetalleVenta

---

# Total de Tablas

14 tablas principales.

---


# Módulo de Seguridad

El módulo de seguridad controla el acceso al sistema y la información general del negocio.

---

# Tabla: Empresa

## Descripción

Almacena la información general del negocio.

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| EmpresaId | int | PK | Sí | Identificador único de la empresa. |
| Nombre | varchar(150) | | Sí | Nombre del negocio. |
| NombreComercial | varchar(150) | | No | Nombre comercial. |
| Propietario | varchar(150) | | Sí | Nombre del propietario. |
| NIT | varchar(30) | | No | Número de identificación tributaria. |
| Direccion | varchar(250) | | Sí | Dirección del negocio. |
| Telefono | varchar(20) | | Sí | Teléfono principal. |
| Correo | varchar(100) | | No | Correo electrónico. |
| Logo | varchar(250) | | No | Ruta del logo del negocio. |
| Activo | bit | | Sí | Estado del registro. |
| FechaCreacion | datetime | | Sí | Fecha de creación. |
| FechaActualizacion | datetime | | No | Fecha de actualización. |

---

# Tabla: Rol

## Descripción

Almacena los diferentes roles que existirán dentro del sistema.

## Registros Iniciales

- Administrador
- Vendedor

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| RolId | int | PK | Sí | Identificador del rol. |
| Nombre | varchar(50) | | Sí | Nombre del rol. |
| Descripcion | varchar(150) | | No | Descripción del rol. |
| Activo | bit | | Sí | Estado del rol. |
| FechaCreacion | datetime | | Sí | Fecha de creación. |

---

# Tabla: Usuario

## Descripción

Almacena la información de los usuarios que podrán ingresar al sistema.

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| UsuarioId | int | PK | Sí | Identificador del usuario. |
| Nombre | varchar(100) | | Sí | Nombre del usuario. |
| Apellido | varchar(100) | | Sí | Apellido del usuario. |
| NombreUsuario | varchar(50) | | Sí | Usuario para iniciar sesión. |
| Correo | varchar(100) | | No | Correo electrónico. |
| PasswordHash | varchar(255) | | Sí | Contraseña cifrada. |
| RolId | int | FK | Sí | Rol asignado al usuario. |
| Activo | bit | | Sí | Estado del usuario. |
| UltimoAcceso | datetime | | No | Último acceso al sistema. |
| FechaCreacion | datetime | | Sí | Fecha de creación. |
| FechaActualizacion | datetime | | No | Fecha de actualización. |

---

# Relaciones del Módulo de Seguridad

- Un Rol puede tener muchos Usuarios.
- Un Usuario pertenece a un solo Rol.
- La Empresa será única dentro del sistema.

---

# Módulo de Catálogos

Los catálogos almacenan la información base que utilizarán los demás módulos del sistema.

---

# Tabla: Categoria

## Descripción

Permite clasificar los productos según su tipo.

## Ejemplos

- Aceites
- Lubricantes
- Cadenas
- Filtros
- Llantas
- Bujías
- Bombillos
- Baterías
- Cascos
- Accesorios

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| CategoriaId | int | PK | Sí | Identificador de la categoría. |
| Nombre | varchar(100) | | Sí | Nombre de la categoría. |
| Descripcion | varchar(250) | | No | Descripción de la categoría. |
| Activo | bit | | Sí | Estado de la categoría. |
| FechaCreacion | datetime | | Sí | Fecha de creación. |

---

# Tabla: Marca

## Descripción

Almacena las marcas de los productos.

## Ejemplos

- Castrol
- Shell
- Mobil
- NGK
- Honda
- Yamaha
- Suzuki
- Toyota
- Nissan
- Bajaj

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| MarcaId | int | PK | Sí | Identificador de la marca. |
| Nombre | varchar(100) | | Sí | Nombre de la marca. |
| Descripcion | varchar(250) | | No | Descripción de la marca. |
| Activo | bit | | Sí | Estado de la marca. |
| FechaCreacion | datetime | | Sí | Fecha de creación. |

---

# Tabla: TipoVehiculo

## Descripción

Define para qué tipo de vehículo aplica un producto.

## Registros Iniciales

- Moto
- Carro
- Tuc Tuc

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| TipoVehiculoId | int | PK | Sí | Identificador del tipo de vehículo. |
| Nombre | varchar(100) | | Sí | Nombre del tipo de vehículo. |
| Descripcion | varchar(250) | | No | Descripción. |
| Activo | bit | | Sí | Estado del registro. |

---

# Tabla: Proveedor

## Descripción

Almacena la información de las empresas proveedoras de los productos.

## Ejemplos

- Canella
- Grupo UMA
- Repuestos XYZ
- Lubricantes GT
- Importadora ABC

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| ProveedorId | int | PK | Sí | Identificador del proveedor. |
| NombreEmpresa | varchar(150) | | Sí | Nombre de la empresa proveedora. |
| Contacto | varchar(150) | | No | Persona de contacto. |
| Telefono | varchar(20) | | No | Teléfono del proveedor. |
| Correo | varchar(100) | | No | Correo electrónico. |
| Direccion | varchar(250) | | No | Dirección del proveedor. |
| NIT | varchar(30) | | No | NIT del proveedor. |
| Observaciones | varchar(300) | | No | Comentarios adicionales. |
| Activo | bit | | Sí | Estado del proveedor. |
| FechaCreacion | datetime | | Sí | Fecha de creación. |

---

# Relaciones del Módulo de Catálogos

- Una Categoría puede tener muchos Productos.
- Una Marca puede tener muchos Productos.
- Un Tipo de Vehículo puede tener muchos Productos.
- Un Proveedor puede suministrar muchos Productos y registrar muchas Compras.

---

# Módulo de Inventario

Este módulo controla todos los productos del negocio y los movimientos de inventario.

---

# Tabla: Producto

## Descripción

Almacena toda la información de los productos que vende el negocio.

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| ProductoId | int | PK | Sí | Identificador del producto. |
| Codigo | varchar(30) | | Sí | Código interno del producto. Debe ser único. |
| CodigoBarras | varchar(100) | | No | Código de barras del producto. |
| Nombre | varchar(200) | | Sí | Nombre del producto. |
| Descripcion | varchar(500) | | No | Descripción del producto. |
| CategoriaId | int | FK | Sí | Categoría del producto. |
| MarcaId | int | FK | Sí | Marca del producto. |
| TipoVehiculoId | int | FK | Sí | Tipo de vehículo al que pertenece. |
| ProveedorPrincipalId | int | FK | No | Proveedor principal del producto. |
| PrecioCosto | decimal(18,2) | | Sí | Último costo registrado. |
| PrecioVenta | decimal(18,2) | | Sí | Precio de venta. |
| StockActual | int | | Sí | Existencia actual. |
| StockMinimo | int | | Sí | Cantidad mínima permitida. |
| Ubicacion | varchar(100) | | No | Ubicación en la bodega. |
| Activo | bit | | Sí | Estado del producto. |
| FechaCreacion | datetime | | Sí | Fecha de creación. |
| FechaActualizacion | datetime | | No | Última actualización. |

---

## Reglas

- El código del producto no puede repetirse.
- No se permitirá precio de venta menor al costo.
- El stock nunca podrá ser negativo.
- Todo cambio de stock deberá registrarse en el Kardex.

---

# Tabla: MovimientoInventario (Kardex)

## Descripción

Registra absolutamente todos los movimientos de inventario realizados en el sistema.

Ningún producto cambiará su existencia sin generar un movimiento.

## Tipos de Movimiento

- Compra
- Venta
- Ajuste
- Devolución Compra
- Devolución Venta
- Producto Dañado
- Entrada Manual
- Salida Manual

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| MovimientoInventarioId | int | PK | Sí | Identificador del movimiento. |
| ProductoId | int | FK | Sí | Producto afectado. |
| TipoMovimiento | varchar(50) | | Sí | Tipo de movimiento. |
| Documento | varchar(30) | | No | Número de factura o documento relacionado. |
| CantidadEntrada | int | | No | Cantidad que ingresó. |
| CantidadSalida | int | | No | Cantidad que salió. |
| StockAnterior | int | | Sí | Existencia antes del movimiento. |
| StockNuevo | int | | Sí | Existencia después del movimiento. |
| Observacion | varchar(300) | | No | Motivo del movimiento. |
| UsuarioId | int | FK | Sí | Usuario que realizó el movimiento. |
| FechaMovimiento | datetime | | Sí | Fecha y hora del movimiento. |

---

# Relaciones del Módulo de Inventario

- Una Categoría puede tener muchos Productos.
- Una Marca puede tener muchos Productos.
- Un TipoVehiculo puede tener muchos Productos.
- Un Producto puede tener muchos Movimientos de Inventario.
- Un Usuario puede registrar muchos Movimientos.

---

# Flujo del Inventario

Compra
↓

MovimientoInventario (+)

↓

Stock aumenta

↓

Venta

↓

MovimientoInventario (-)

↓

Stock disminuye

↓

Ajuste

↓

MovimientoInventario

↓

Stock actualizado

---

# Alertas

El sistema deberá mostrar una alerta cuando:

- El StockActual sea menor o igual al StockMinimo.
- El producto esté inactivo.
- El precio de venta sea menor al precio de costo.

---

# Módulo de Compras y Ventas

Este módulo administra las compras realizadas a proveedores y las ventas realizadas a los clientes.

---

# Tabla: Cliente

## Descripción

Almacena la información de los clientes registrados.

## Nota

El sistema permitirá realizar ventas al **Consumidor Final** sin necesidad de registrar un cliente.

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| ClienteId | int | PK | Sí | Identificador del cliente. |
| Nombre | varchar(150) | | Sí | Nombre completo del cliente. |
| NIT | varchar(30) | | No | NIT del cliente. |
| Telefono | varchar(20) | | No | Teléfono. |
| Direccion | varchar(250) | | No | Dirección. |
| Correo | varchar(100) | | No | Correo electrónico. |
| Activo | bit | | Sí | Estado del cliente. |
| FechaCreacion | datetime | | Sí | Fecha de creación. |

---

# Tabla: Compra

## Descripción

Representa la compra realizada a un proveedor.

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| CompraId | int | PK | Sí | Identificador de la compra. |
| NumeroFactura | varchar(50) | | Sí | Número de factura del proveedor. |
| ProveedorId | int | FK | Sí | Proveedor de la compra. |
| UsuarioId | int | FK | Sí | Usuario que registró la compra. |
| FechaCompra | datetime | | Sí | Fecha de la compra. |
| SubTotal | decimal(18,2) | | Sí | Subtotal de la compra. |
| Descuento | decimal(18,2) | | No | Descuento aplicado. |
| Total | decimal(18,2) | | Sí | Total de la compra. |
| Observaciones | varchar(300) | | No | Observaciones. |

---

# Tabla: DetalleCompra

## Descripción

Detalle de productos comprados.

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| DetalleCompraId | int | PK | Sí | Identificador del detalle. |
| CompraId | int | FK | Sí | Compra relacionada. |
| ProductoId | int | FK | Sí | Producto comprado. |
| Cantidad | int | | Sí | Cantidad comprada. |
| PrecioCosto | decimal(18,2) | | Sí | Precio de costo unitario. |
| SubTotal | decimal(18,2) | | Sí | Subtotal del detalle. |

---

# Tabla: Venta

## Descripción

Representa una venta realizada a un cliente.

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| VentaId | int | PK | Sí | Identificador de la venta. |
| NumeroVenta | varchar(30) | | Sí | Correlativo de la venta. |
| ClienteId | int | FK | No | Cliente (opcional). |
| UsuarioId | int | FK | Sí | Usuario que realizó la venta. |
| FechaVenta | datetime | | Sí | Fecha de la venta. |
| SubTotal | decimal(18,2) | | Sí | Subtotal. |
| Descuento | decimal(18,2) | | No | Descuento. |
| Total | decimal(18,2) | | Sí | Total de la venta. |
| Observaciones | varchar(300) | | No | Observaciones. |

---

# Tabla: DetalleVenta

## Descripción

Detalle de productos vendidos.

## Campos

| Campo | Tipo | Clave | Requerido | Descripción |
|---|---|---|---|---|
| DetalleVentaId | int | PK | Sí | Identificador del detalle. |
| VentaId | int | FK | Sí | Venta relacionada. |
| ProductoId | int | FK | Sí | Producto vendido. |
| Cantidad | int | | Sí | Cantidad vendida. |
| PrecioVenta | decimal(18,2) | | Sí | Precio unitario. |
| Descuento | decimal(18,2) | | No | Descuento aplicado. |
| SubTotal | decimal(18,2) | | Sí | Subtotal del detalle. |

---

# Relaciones Generales

Empresa
│
├── Usuario
│     │
│     └── Rol
│
├── Categoria
├── Marca
├── TipoVehiculo
├── Proveedor
│
├── Producto
│     │
│     └── MovimientoInventario
│
├── Compra
│     └── DetalleCompra
│
├── Cliente
│
└── Venta
      └── DetalleVenta

---

# Reglas Importantes

## Compras

- Toda compra debe tener un proveedor.
- Toda compra debe tener al menos un detalle.
- Al guardar una compra el inventario aumentará automáticamente.
- El costo del producto podrá actualizarse con la última compra.

---

## Ventas

- Toda venta debe tener al menos un producto.
- No se permitirá vender más productos de los disponibles.
- Al guardar la venta el inventario disminuirá automáticamente.
- Se registrará un movimiento en el Kardex.

---

## Inventario

- Ningún producto podrá tener stock negativo.
- Todo cambio de existencia quedará registrado.
- El Kardex almacenará el historial completo.

---

# Resumen de Tablas

1. Empresa
2. Rol
3. Usuario
4. Categoria
5. Marca
6. TipoVehiculo
7. Proveedor
8. Producto
9. MovimientoInventario
10. Cliente
11. Compra
12. DetalleCompra
13. Venta
14. DetalleVenta

Total: 14 tablas principales.