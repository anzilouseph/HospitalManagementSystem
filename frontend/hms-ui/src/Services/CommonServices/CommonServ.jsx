import axios from "axios";


    // Helper function to get headers with token if available
    const getHeaders = () => {
        const token = localStorage.getItem('accessToken');
        return {
        headers: {
            'Authorization': `Bearer ${token}`,
        }
        };
    };


const CommonServices = 
{
  login:async(data)=>
        {
            try{
                const response = await axios.post(`https://localhost:7097/api/AuthenticationManagementController/login`);
                return response.data;
            }
            catch(error)
            {
                throw(error);
            }
        },

    getAllUser:async()=>
    {
        try{
            const response = await axios.get(`https://localhost:7097/api/AdminManagementController/get-all-employees`);
            return response.data;
        }
        catch(error)
        {
            throw(error);
        }
    },
    getOwnData :async()=>
    {
        try{
            const response = await axios.get(`https://localhost:7097/api/EmployeeManagement/get-own-profile`,getHeaders());
            return response.data;
        }
        catch(error)
        {
            throw (error);
        }
    }
}

export default CommonServices;