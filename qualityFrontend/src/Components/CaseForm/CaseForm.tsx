import React, { useEffect, useState } from "react";
import { CaseFormData, schema } from "./schema";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import styles from "./CaseForm.module.scss";
import { getAllProducts, Product } from "../../Services/qualityServices";

type FormType = "CREATE" | "EDIT";

interface CaseFormProps {
  formType?: FormType;
  onSubmit: (data: CaseFormData) => unknown;
  defaultValues?: CaseFormData;
}

const CaseForm = ({
  formType = "CREATE",
  defaultValues = {
    productId: 0,
    description: "",
    quantity: 0,
    locationId: 0,
  },
  onSubmit,
}: CaseFormProps) => {
  const [products, setProducts] = useState<Product[]>([]);

  const {
    reset,
    register,
    watch,
    setValue,
    formState: { errors, isSubmitSuccessful },
    handleSubmit,
  } = useForm<CaseFormData>({
    resolver: zodResolver(schema),
    defaultValues,
  });

  useEffect(() => {
    getAllProducts()
      .then((data) => setProducts(data))
      .catch((e) => console.log(e));
  }, []);

  isSubmitSuccessful && reset();

  return (
    <div>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className={styles.input}>
          <label htmlFor="productId">Product</label>
          <select id="productId" {...register("productId", {valueAsNumber: true})}>
            <option disabled value="">
              Please choose a Product
            </option>
            {products.map((product) => (
                <option key={product.id} value={product.id}>{product.sku} {product.name}</option>
            ))}
          </select>
          {errors?.productId && <small>{errors.productId.message}</small>}
        </div>
        <div className={styles.input}>
          <label htmlFor="description">Description</label>
          <textarea
            id="description"
            {...register("description")}
            rows={4}
            cols={40}
            placeholder="Please describe the product defect in detail. Use objective language."
          />
          {errors?.description && <small>{errors.description.message}</small>}
        </div>
        <div className={styles.input}>
          <label htmlFor="quantity">Quantity Claimed</label>
          <input type="number" id="quantity" {...register("quantity", {valueAsNumber: true})} />
          {errors?.quantity && <small>{errors.quantity.message}</small>}
        </div>
        <div className={styles.input}>
          <label htmlFor="locationId">Storage Location</label>
          <input type="text" id="locationId" {...register("locationId", {valueAsNumber: true})} />
          {errors?.locationId && <small>{errors.locationId.message}</small>}
        </div>
        <button>{formType === "CREATE" ? "Create" : "Edit"}</button>
      </form>
    </div>
  );
};

export default CaseForm;
