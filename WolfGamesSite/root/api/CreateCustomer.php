<?php
        $db = mysql_connect('68.178.217.40', 'wolfmaindb', 'Acc3ss@M41n') or die('Could not connect: ' . mysql_error());
        mysql_select_db('wolfmaindb') or die('Could not select database');

        // Strings must be escaped to prevent SQL injection attack.
        $lastName = mysql_real_escape_string($_GET['lastName'], $db);
        $score = mysql_real_escape_string($_GET['score'], $db);
        $hash = $_GET['hash'];

        $secretKey="WolfGamesSecretKey"; # Change this value to match the value stored in the client javascript below

        $real_hash = md5($position_x . $position_y . $score . $secretKey);
//        if($real_hash == $hash) {
            // Send variables for the MySQL database class.
            $query = "insert into Customer values (NULL, NULL, NULL, NULL, '$lastName', NULL, NULL, NULL, '$score');";
            $result = mysql_query($query) or die('Query failed: ' . mysql_error());
//        }
//        echo "pos_x = {" . $position_x . "}\tpos_y = {" . $position_y . "}\tscore = {" . $score . "}\n";
//        echo "real_hash = {" . $real_hash . "}\thash = {" . $hash . "}\n"; 
?>