import react from "react";
import { Routes,Router,Route } from "react-router-dom";
import Log from "../Pages/loginComponent/Log";

const RouteFile = ()=>
{
return(
    <Routes>
        <Route path="/" element={<Log/>}/>
    </Routes>
);

}
export default RouteFile;