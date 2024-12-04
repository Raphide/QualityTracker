import "./App.css";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import LandingPage from "./Pages/LandingPage/LandingPage";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import NavBar from "./Components/NavBar/NavBar";
import CasesSearchPage from "./Pages/CasesSearchPage/CasesSearchPage";
import CreateCasePage from "./Pages/CreateCasePage/CreateCasePage";

function App() {
  const queryClient = new QueryClient();

  return (
    <>
      <BrowserRouter future={{ v7_relativeSplatPath: true }}>
        <QueryClientProvider client={queryClient}>
          <h1>Product Quality Tracker</h1>
          <NavBar />
          <Routes>
            <Route path="/" element={<LandingPage />} />
            <Route path="/cases" element={<CasesSearchPage />} />
            <Route path="/cases/create" element={<CreateCasePage />} />
          </Routes>
        </QueryClientProvider>
      </BrowserRouter>
    </>
  );
}

export default App;
