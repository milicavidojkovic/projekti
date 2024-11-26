<?php
    $db_server="localhost:3307";
    $db_user="root";
    $db_pass="";
    $db_name="database";
    $conn="";
    try{
        $conn=mysqli_connect($db_server, $db_user, $db_pass, $db_name);
    
    }
    catch(mysqli_sql_exception){
        echo "you are not connected<br>";
    }
    
    if($conn){
        echo "connected to the database<br>";
    }
   
?>