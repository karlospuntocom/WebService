<h1 class="page-header"><span class="glyphicon glyphicon-apple"></span> ALUMNOS COLEGIO </h1>

<table class="table table-striped">
	<thead>
		<tr>
			<th style="width: 180px;">Código</th>
			<th style="width: 180px;">Nombre</th>
			<th>Apellido</th>
			<th>Edad</th>
			<th>Editar</th>
			<th>Eliminar</th>
		</tr>
	</thead>
	<tbody>
		<?php 
		$j =0;
		for ($i=0; $i < ($columnas-1) ; $i++) { 
			$j++;
			if ($j==5) {
				echo"<td style='width:60px;'><span class='glyphicon glyphicon-pencil'></span></td> <td style='width:60px;'> <span class='glyphicon glyphicon-trash'></span></td></tr>";
				$j=1;
			}
			echo "<td>".$resultado['listarResult']['string'][$i]." </td> ";
		}
		?>
	</tbody>
</table>
<div class="well well-sm text-right">
	<a class="btn btn-primary"> Nuevo Alumno </a>
</div>