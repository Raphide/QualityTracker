import * as z from "zod";

export const schema = z.object({
productId: z.number().min(1, "Must choose a product"),
description: z.string().min(3, "Must input a description"),
quantity: z.number(),
locationId: z.number()
});

export type CaseFormData = z.infer<typeof schema>;