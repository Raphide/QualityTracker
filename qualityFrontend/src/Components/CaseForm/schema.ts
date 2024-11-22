import * as z from "zod";

export const schema = z.object({

});

export type CaseFormData = z.infer<typeof schema>;