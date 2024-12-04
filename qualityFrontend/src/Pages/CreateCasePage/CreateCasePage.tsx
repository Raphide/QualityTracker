import React from 'react'
import CaseForm from '../../Components/CaseForm/CaseForm'
import { CaseFormData } from '../../Components/CaseForm/schema'

const CreateCasePage = () => {
    const handlesubmit = async (data: CaseFormData) => {
        console.log(data)
      }
  return (
    <div><CaseForm onSubmit={handlesubmit}/></div>
  )
}

export default CreateCasePage