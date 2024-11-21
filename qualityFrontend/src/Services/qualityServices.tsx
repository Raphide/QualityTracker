import axios from "axios";

const baseURL = import.meta.env.VITE_APP_API_BASE_URL;

export interface CaseResponse {
  id: number;
  caseNumber: string;
  product: Product;
  description: string;
  startDate: string;
  endDate: any;
  quantity: number;
  location: Location;
  isActive: boolean;
  outcome: string;
  recoveredCost: number;
}
export interface Product {
  id: number;
  name: string;
  sku: string;
  department: string;
  costPrice: number;
  retailPrice: number;
  unitWeight: number;
}
export interface Location {
  id: number;
  shelf: number;
  level: number;
  aisle: number;
  fullLocation: string;
  isOccupied: boolean;
  caseId: number;
}

export const getAllCases = async () => {
    const response = await axios.get<CaseResponse[]>(baseURL + "/cases");
    if(response.status !== 200){
        throw new Error("failed to fetch cases");
    }
    return response.data;
}