import React, { useState } from "react";
import { useForm } from "react-hook-form"; // Correct import
import { message } from "antd";
import CommonServices from "../../Services/CommonServices/CommonServ";

const Log = () => {
  const [loading, setLoading] = useState(false);
  const { register, handleSubmit, formState: { errors } } = useForm();
  const [responseError, setResponseError] = useState("");

  const onFinish = async (data) => {
    setLoading(true);
    setResponseError(""); // Clear previous errors
    try {
      const response = await CommonServices.login(data);
      if (response.status) {
        console.log("login successful", response.data);
        localStorage.setItem("accessToken", response.data);

        try {
          const response2 = await CommonServices.getOwnData();
          if (response2.status) {
            if (response2.data.roleName === "Admin") {
              message.success("You are an admin");
              console.log("You are an admin");
              // Redirect to admin dashboard
            } else {
              console.log("You are not an admin");
              // Redirect to user dashboard
            }
          } else {
            setResponseError(response2.message);
          }
        } catch (error) {
          setResponseError(error.message);
        }
      } else {
        setResponseError(response.data?.message || "Login failed");
      }
    } catch (error) {
      setResponseError(error.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <>
      <div className="container mt-5">
        <div className="row justify-content-center">
          <div className="col-lg-6">
            <div className="card">
              <div className="card-header bg-primary text-center">
                <h3 style={{ color: 'white', margin: 0 }}>Login</h3>
              </div>
              <div className="card-body p-4">
                {responseError && (
                  <div className="alert alert-danger" role="alert">
                    {responseError}
                  </div>
                )}
                
                <form onSubmit={handleSubmit(onFinish)}>
                  <div className="mt-3">
                    <label className="form-label">EMAIL</label>
                    <input 
                      type="email" 
                      className="form-control" 
                      placeholder="Enter email address"
                      {...register("email", {
                        required: "Email is required",
                        pattern: {
                          value: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/,
                          message: "Invalid email format"
                        }
                      })}
                    />
                    {errors.email && (
                      <p style={{ color: "red", fontSize: "0.875rem" }}>
                        {errors.email.message}
                      </p>
                    )}
                  </div>
                  
                  <div className="mt-3">
                    <label className="form-label">PASSWORD</label>
                    <input 
                      type="password" // Changed from "text" to "password"
                      className="form-control" 
                      placeholder="Enter your password"
                      {...register("password", {
                        required: "Password is required"
                      })}
                    />
                    {errors.password && (
                      <p style={{ color: "red", fontSize: "0.875rem" }}>
                        {errors.password.message}
                      </p>
                    )}
                  </div>
                  
                  <div className="d-grid gap-2 mt-4"> 
                    <button 
                      type="submit" 
                      className="btn btn-success btn-lg"
                      disabled={loading}
                    >
                      {loading ? "Logging in..." : "Login"}
                    </button>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Log;