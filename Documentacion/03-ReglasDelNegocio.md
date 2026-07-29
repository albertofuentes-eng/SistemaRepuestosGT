# Reglas del Negocio

## Productos

- Cada producto debe tener un código único.
- Un producto pertenece a una sola categoría.
- Un producto pertenece a una sola marca.
- Un producto pertenece a un solo tipo de vehículo.
- Un producto puede tener código de barras (opcional).
- Un producto no puede tener precio de venta menor al precio de costo.
- Un producto puede estar activo o inactivo.

---

## Inventario

- El inventario aumenta únicamente cuando se registra una compra.
- El inventario disminuye únicamente cuando se registra una venta.
- No se permitirá vender más productos de los disponibles.
- Todo movimiento de inventario debe quedar registrado en el Kardex.
- El sistema mostrará alerta cuando el stock sea menor al stock mínimo.

---

## Compras

- Toda compra debe tener un proveedor.
- Una compra debe contener al menos un producto.
- Al guardar una compra, el inventario se actualizará automáticamente.
- El costo del producto podrá actualizarse con la última compra.

---

## Ventas

- Toda venta debe contener al menos un producto.
- No se permitirá vender productos sin existencia.
- Al finalizar una venta se descontará automáticamente el inventario.
- El sistema calculará automáticamente el subtotal, impuestos (si aplica) y total.

---

## Clientes

- Se podrán realizar ventas sin registrar cliente (Consumidor Final).
- Los clientes registrados podrán tener historial de compras.

---

## Proveedores

- Un proveedor podrá suministrar varios productos.
- El historial de compras por proveedor quedará almacenado.

---

## Usuarios

- Cada usuario tendrá un rol.
- Solo el administrador podrá eliminar registros importantes.
- Toda acción importante quedará registrada en la bitácora.

---

## Reportes

El sistema deberá generar como mínimo:

- Ventas por fecha.
- Compras por fecha.
- Inventario actual.
- Productos con bajo inventario.
- Productos más vendidos.

---

## Seguridad

- Las contraseñas se almacenarán cifradas.
- Ningún usuario podrá acceder sin iniciar sesión.
- El sistema controlará los permisos según el rol del usuario.