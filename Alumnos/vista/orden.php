<h1 class="page-header"><span class="glyphicon glyphicon-apple"></span> ÓRDENES DE SERVICIO </h1>

<table class="table table-striped">
	<thead>
		<tr>
			<th style="width: 180px;">Id</th>
			<th style="width: 180px;">Id Cliente</th>
			<th>Fecha / Hora</th>
			<th>Descripción</th>
			<th>Cantidad Productos</th>
			<th>Costo total</th>
			<th>Eliminar</th>
			<th>Editar</th>
		</tr>
	</thead>
	<tbody>
		<?php
		$j =0;
		for ($i=0; $i < ($columnas	) ; $i++) {
			$j++;
			if ($j==7) {
				echo"<td style='width:60px;'><a class='btn btn-primary' href='eliminar.php?id=".$resultado['listarResult']['string'][0]."'>Eliminar</a></td> <td style='width:60px;'> <a class='btn btn-primary'>Editar</a></td></tr>";
				$j=1;
			}
			echo "<td>".$resultado['listarResult']['string'][$i]." </td> ";
		}
		?>
	</tbody>
</table>
<div class="well well-sm text-right">
	<a class="btn btn-primary"> Nueva Orden</a>
</div>
