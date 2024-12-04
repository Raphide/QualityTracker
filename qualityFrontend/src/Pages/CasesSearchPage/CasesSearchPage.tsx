import React from "react";
import { useQuery } from "@tanstack/react-query";
import { getAllCases } from "../../Services/qualityServices";

const CasesSearchPage = () => {
    const { isFetching, isPending, isError, data, error } = useQuery({
        queryKey: ["cases"],
        queryFn: () => getAllCases(),
      });
    
      if (isError) {
        console.log(error.message);
      }
    
  return (
    <div>
      <table>
        <thead>
          <tr>
            <th>Case ID</th>
            <th>Product Name</th>
            <th>SKU</th>
            <th>Department</th>
            <th>Start Date</th>
            <th>Quantity Claimed</th>
            <th>Total Cost</th>
            <th>Storage Location</th>
            <th>Total weight</th>
          </tr>
        </thead>
        <tbody>
        {!isFetching && !isPending && data?.sort((a, b) => a.id - b.id).map((cases) => (
          <tr key={cases.id}>
            <td>{cases.id}</td>
            <td>{cases.product.name}</td>
            <td>{cases.product.sku}</td>
            <td>{cases.product.department}</td>
            <td>{cases.startDate}</td>
            <td>{cases.quantity}</td>
            <td>${cases.quantity * cases.product.costPrice}</td>
            <td>{cases.location.fullLocation}</td>
            <td>{cases.quantity * cases.product.unitWeight} kg</td>
          </tr>
        ))}
        </tbody>
      </table>
    </div>
  );
};

export default CasesSearchPage;
