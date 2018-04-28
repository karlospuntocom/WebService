<?php
$id= array('id' =>$_GET["id"]);
echo $id;
require_once 'lib/nusoap.php';

$wsdl = "http://localhost:53147/WebService1.asmx?wsdl";
$cliente = new nusoap_client($wsdl, true);
$resultado = $cliente->call('eliminar', $id);

print_r ($resultado);

include 'index.php';
?>
