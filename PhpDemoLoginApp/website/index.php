<?php
    include("database.php");
?> 
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <form action ="<?php htmlspecialchars($_SERVER["PHP_SELF"]) ?>" method="post">
            <h2> My small demo app</h2>
            <h3>Login page</h3>
            username:<br>
            <input type="text" name="username"><br>
            password:<br>
            <input type="text" name="password"><br>
            <input type="submit"name="submit" value="Log in">
    </form>
</body>
</html>


<?php
    if($_SERVER["REQUEST_METHOD"]=="POST"){
        $username=filter_input(INPUT_POST, "username", FILTER_SANITIZE_SPECIAL_CHARS);
        $password=filter_input(INPUT_POST, "password", FILTER_SANITIZE_SPECIAL_CHARS);

        if(empty($password)){
            echo "Password is not entered";

        }
        elseif(empty($username)){
            echo "Username is not entered";
        }
        else {
            $hash= password_hash($password, PASSWORD_DEFAULT);
            $sql= "INSERT INTO users(user, password) VALUES ('$username', '$hash')";
            try{
                mysqli_query($conn, $sql);
                echo "You are registerd";
        }
        catch(mysqli_sql_exception){
            echo "That username is taken";
        }
        }
        
    }
    mysqli_close($conn);
?> 