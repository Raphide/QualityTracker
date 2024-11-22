import React from 'react'
import { CaseFormData } from './schema';

type FormType = "CREATE" | "EDIT";

interface CaseFormProps {
    formType?: FormType;
    onSubmit: (data: CaseFormData) => unknown;
    defaultValues?: CaseFormData;
}

const CaseForm = ({}) => {
  return (
    <div>CaseForm</div>
  )
}

export default CaseForm