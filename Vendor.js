const express = require("express");
const router = express.Router();

// Dummy vendor data
let vendors = [
    { id: 1, name: "Vendor One", description: "High-quality electronics supplier." },
    { id: 2, name: "Vendor Two", description: "Leading fashion brand." }
];

// Get all vendors
router.get("/", (req, res) => {
    res.json(vendors);
});

// Add a new vendor
router.post("/", (req, res) => {
    const { name, description } = req.body;
    const newVendor = { id: vendors.length + 1, name, description };
    vendors.push(newVendor);
    res.status(201).json(newVendor);
});

module.exports = router;
