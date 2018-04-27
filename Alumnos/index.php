<?php

require_once 'lib/nusoap.php';
$wsdl = "http://localhost:53147/WebService1.asmx?wsdl";
$cliente = new nusoap_client($wsdl, true);
$resultado = $cliente->call(listar);
$columnas = ceil(count($resultado,1)/count($resultado,0))-1;

include 'vista/header.php';
include 'vista/orden.php';
include 'vista/footer.php';

?>
